package main

import (
	"regexp"
	"strings"
	"unicode/utf8"
)

type H1info struct {
	cleaned  string
	length   int
	position int
}
type MarkdownParser struct {
	text        string
	headersInfo []H1info
}

func NewMarkdownParser(text string) *MarkdownParser {
	var temp []H1info
	mp := MarkdownParser{strings.Replace(text, "\r\n", "\n", -1), temp}
	return &mp
}
func (mp *MarkdownParser) Headers() []string {
	re := regexp.MustCompile(`(?m)(^#{1}[^#].+\n$)|(^.+\n=+$)|(^##\n$)|(^#[^#]\n$)`)
	result := re.FindAllStringSubmatch(mp.text, -1)
	var sl []string
	for i := 0; i < len(result); i++ {
		if len(result[i][0]) == 3 && result[i][0][0] == '#' && result[i][0][1] == '#' && result[i][0][2] == 10 {
			sl = append(sl, "#")
			re1 := regexp.MustCompile(`(?m)^##\n$`)
			inf := H1info{"#", len(result[i][0]), re1.FindStringIndex(mp.text)[0]}
			mp.headersInfo = append(mp.headersInfo, inf)
			continue
		}
		s := result[i][0]
		s = strings.TrimSpace(s)
		s = strings.TrimLeft(s, "#")
		s = strings.TrimSpace(s)
		s = strings.TrimRight(s, "=")
		s = strings.TrimSpace(s)
		sl = append(sl, s)
		inf := H1info{s, len(result[i][0]), strings.Index(mp.text, result[i][0])}
		mp.headersInfo = append(mp.headersInfo, inf)
	}
	return sl
}
func (mp *MarkdownParser) SubHeadersOf(header string) []string {
	var start int
	var end int
	mp.Headers()
	for index, value := range mp.headersInfo {
		if header == value.cleaned {
			start = value.position + value.length
			nextOne := index + 1
			if index == len(mp.headersInfo)-1 {
				end = len(mp.text) - 1
			} else {
				end = mp.headersInfo[nextOne].position
			}
		}
	}
	textBetweenTwoH1 := mp.text[start:end]
	re := regexp.MustCompile(`(?m)(^#{2}[^#].+$)|(^.+\s-+$)|(^#{2}[^#]\s$)|(^###\s$)`)
	result := re.FindAllStringSubmatch(textBetweenTwoH1, -1)
	var sl []string
	for i := 0; i < len(result); i++ {
		s := result[i][0]
		s = strings.TrimSpace(s)
		s = strings.TrimLeft(s, "#")
		s = strings.TrimSpace(s)
		s = strings.TrimRight(s, "-")
		s = strings.TrimSpace(s)
		sl = append(sl, s)
	}
	return sl
}
func startIndex(str string) (first int, second int) {
	count := 0
	firstUpperLetter := -1
	secondUpperLetter := -1
	i := 0
	for len(str) > 0 {
		r, size := utf8.DecodeRuneInString(str)
		if (r >= 65 && r <= 90) || (r >= 1040 && r <= 1071) {
			count++
			switch count {
			case 1:
				firstUpperLetter = i
				break
			case 2:
				secondUpperLetter = i
				break
			}
		}
		i++
		str = str[size:]
	}
	return firstUpperLetter, secondUpperLetter
}
func isEndOfSentence(input uint8) bool {
	if input == 33 || input == 34 || input == 46 || input == 59 || input == 63 {
		return true
	}
	return false
}
func (mp *MarkdownParser) Names() []string {
	re := regexp.MustCompile(`(?m)([^.!?";][ ]+[A-ZА-Я][a-zа-я]+ +[A-ZА-Я][a-zа-я]+([ -]*[A-ZА-Я][a-zа-я]*)*)|(.[ ]*[A-ZА-Я][a-zа-я]+[ ]*-[ ]*([ -]*[A-ZА-Я][a-zа-я]+)*)`)
	result := re.FindAllStringSubmatch(mp.text, -1)
	var sl []string
	var index int
	for i := 0; i < len(result); i++ {
		if isEndOfSentence(result[i][0][0]) {
			_, index = startIndex(result[i][0])
			if index == -1 {
				continue
			}
		} else {
			index, _ = startIndex(result[i][0])
			if index == -1 {
				continue
			}
		}
		sl = append(sl, strings.TrimSpace(result[i][0][index:]))
	}
	return sl
}
func isDigit(input uint8) bool {
	if input >= 48 && input <= 57 {
		return true
	}
	return false
}
func checkPhone(input string) bool {
	digit := false
	goodFirst := false
	noPlusInside := true
	noNewLines := true
	if isDigit(input[0]) {
		goodFirst = true
	} else if input[0] == 40 {
		goodFirst = true
	} else if input[0] == 43 {
		goodFirst = true
	}
	for i, _ := range input {
		if isDigit(input[i]) {
			digit = true
		}
		if input[i] == 43 && i > 0 {
			noPlusInside = false
		}
		if input[i] == 13 && i > 0 {
			noNewLines = false
		}
	}
	return digit && goodFirst && noPlusInside && noNewLines
}
func (mp *MarkdownParser) PhoneNumbers() []string {
	re := regexp.MustCompile(`(?m).[(+\d]\d+([\d()+ ]*[- ]*\d)*[)]*`)
	result := re.FindAllStringSubmatch(mp.text, -1)
	var sl []string
	for i := 0; i < len(result); i++ {
		s := result[i][0]
		s = strings.TrimSpace(s)
		if checkPhone(s) {
			sl = append(sl, s)
		}
	}
	return sl
}
func getLink(input string) string {
	startIndex := 0
	for i := 0; i < len(input); i++ {
		if input[i] == 40 {
			if input[i-1] == 93 {
				startIndex = i
			}
		}
	}
	return string(input[startIndex+1 : len(input)-1])
}
func (mp *MarkdownParser) Links() []string {
	re := regexp.MustCompile(`(?m)\[.*\]\(https?:\/\/[\w\.]*[0-9a-z]+\.[-_0-9a-z]+[\/]*[\w-.?=*#\/$_]*\)$`)
	result := re.FindAllStringSubmatch(mp.text, -1)
	var sl []string
	for i := 0; i < len(result); i++ {
		sl = append(sl, getLink(result[i][0]))
	}
	return sl
}
func checkMail(input string) bool {
	if (input[0] >= 97 && input[0] <= 122) || (input[0] >= 65 && input[0] <= 90) || (input[0] >= 0 && input[0] <= 9) {
		return true
	}
	return false
}
func (mp *MarkdownParser) Emails() []string {
	re := regexp.MustCompile(`(?m).[A-Za-z0-9]+[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}`)
	result := re.FindAllStringSubmatch(mp.text, -1)
	var sl []string
	for i := 0; i < len(result); i++ {
		if checkMail(result[i][0]) {
			sl = append(sl, strings.TrimSpace(result[i][0]))
		}
	}
	return sl
}
