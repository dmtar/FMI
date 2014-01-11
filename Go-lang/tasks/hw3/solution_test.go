package main

import (
	"io/ioutil"
	"testing"
)

func loadTheReadme() string {
	content, err := ioutil.ReadFile("./README.md")
	if err != nil {
		return ""
	}
	return string(content)
}

func TestHeaders(t *testing.T) {
	mdParser := NewMarkdownParser(loadTheReadme())
	headers := mdParser.Headers()
	if headers[0] != "MarkdownParser" {
		t.Fail()
	}
}

func TestSubHeadersOf(t *testing.T) {
	mdParser := NewMarkdownParser(loadTheReadme())
	subHeaders := mdParser.SubHeadersOf("MarkdownParser")
	if subHeaders[0] != "type MarkdownParser" {
		t.Fail()
	}
}
func TestNames(t *testing.T) {
	mdParser := NewMarkdownParser(loadTheReadme())
	names := mdParser.Names()
	if names[len(names)-1] != "Това Трябва Да Е" {
		t.Fail()
	}
}

func TestPhoneNumbers(t *testing.T) {
	mdParser := NewMarkdownParser(loadTheReadme())
	numbers := mdParser.PhoneNumbers()
	if numbers[len(numbers)-1] != "+359 41 41 41" {
		t.Fail()
	}
}

func TestLinks(t *testing.T) {
	mdParser := NewMarkdownParser(loadTheReadme())
	links := mdParser.Links()
	if links[len(links)-1] != "http://test.wtf/page.php?dafuq=1" {
		t.Fail()
	}
}

func TestEmails(t *testing.T) {
	mdParser := NewMarkdownParser(loadTheReadme())
	emails := mdParser.Emails()
	if emails[len(emails)-1] != "wtf+wtf2@test.co.uk" {
		t.Fail()
	}
}
