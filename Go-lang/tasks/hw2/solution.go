package main

import (
	"math"
	"strings"
)

type Header struct {
	format    string
	lineWidth int
	encoding  string
}
type Colors struct {
	Red   byte
	Green byte
	Blue  byte
}
type Pixel struct {
	numOfIndenticalPxl int
	Red                float64
	Green              float64
	Blue               float64
	Alpha              float64
	byteColorData      []byte
}

func (p *Pixel) Color() Colors {

	clrs := new(Colors)
	clrs.Red = p.byteColorData[0]
	clrs.Green = p.byteColorData[1]
	clrs.Blue = p.byteColorData[2]
	return *clrs
}
func RoundViaFloat(x float64, prec int) float64 {
	var rounder float64
	pow := math.Pow(10, float64(prec))
	intermed := x * pow
	_, frac := math.Modf(intermed)
	if frac >= 0.5 {
		rounder = math.Ceil(intermed)
	} else {
		rounder = math.Floor(intermed)
	}

	return rounder / pow
}
func (p *Pixel) precomputing() {
	p.Red = p.Red * p.Alpha
	p.Green = p.Green * p.Alpha
	p.Blue = p.Blue * p.Alpha

	red := byte(int32(RoundViaFloat(p.Red, 0)))
	green := byte(int32(RoundViaFloat(p.Green, 0)))
	blue := byte(int32(RoundViaFloat(p.Blue, 0)))
	p.byteColorData = []byte{red, green, blue}
}

type Image struct {
	data   []Pixel
	header Header
}
type myError struct {
	errorMessage string
}

func (m myError) Error() string {
	return m.errorMessage
}
func (i Image) InspectPixel(x int, y int) (*Pixel, *myError) {
	errHandle := new(myError)
	catchPxlIndx := 0
	if x > i.header.lineWidth {
		errHandle.errorMessage = "You are looking for pixel out of the grid"
		return nil, errHandle
	} else {
		searchedIndex := y*i.header.lineWidth + x
		for _, value := range i.data {
			catchPxlIndx += value.numOfIndenticalPxl
			if catchPxlIndx > searchedIndex {
				return &value, nil
			}
			continue
		}
		errHandle.errorMessage = "You are looking for pixel out of the grid"
		return nil, errHandle
	}
}
func calculateAlpha(a float64) float64 {
	var temp float64 = a / 255
	return temp
}
func checkInput(data []byte, header Header) bool {
	if header.encoding != "RLE" && header.encoding != "None" {
		return false
	}
	for i := 0; i < len(header.format); i++ {
		temp := header.format[i]
		if temp == 'R' || temp == 'G' || temp == 'B' || temp == 'A' {
			continue
		}
		return false
	}
	if header.encoding == "RLE" {
		if len(data)%(len(header.format)+1) != 0 {
			return false
		}
	} else if header.encoding == "None" {
		if len(data)%len(header.format) != 0 {
			return false
		}
	}
	return true
}
func ParseImage(data []byte, header Header) (*Image, *myError) {
	if !checkInput(data, header) {
		err := new(myError)
		err.errorMessage = "Something went wrong with your input, check your data array, encoding and format strings"
		return nil, err
	}
	pixelSize := 0
	encdng := false
	if header.encoding == "RLE" {
		encdng = true
		if len(header.format) == 3 {
			pixelSize = 4
		} else if len(header.format) == 4 {
			pixelSize = 5
		}
	} else {
		pixelSize = len(header.format)
	}
	pixelsCount := len(data) / pixelSize
	pImage := new(Image)
	pImage.header.lineWidth = header.lineWidth
	for i := 0; i < pixelsCount; i++ {
		test := data[:pixelSize]
		data = data[pixelSize:]
		pixel := new(Pixel)
		if !encdng {
			pixel.numOfIndenticalPxl = 1
		}
		indexCorrector := 0
		for j := 0; j < pixelSize; j++ {
			if encdng && j == 0 {
				pixel.numOfIndenticalPxl = int(test[0])
				indexCorrector = 1
				continue
			}
			switch header.format[j-indexCorrector] {
			case 'R':
				pixel.Red = float64(test[j])
			case 'G':
				pixel.Green = float64(test[j])
			case 'B':
				pixel.Blue = float64(test[j])
			case 'A':
				pixel.Alpha = float64(test[j])
			}
		}
		if strings.Index(header.format, "A") == -1 {
			pixel.Alpha = 1.0
		} else {
			pixel.Alpha = calculateAlpha(pixel.Alpha)
		}
		pixel.precomputing()
		pImage.data = append(pImage.data, *pixel)
	}
	return pImage, nil
}
func main() {
	data := []byte{0, 12, 244, 127, 13, 26, 52, 100, 31, 33, 41, 255}
	header := Header{"BGRA", 3, "None"}
	image, err1 := ParseImage(data, header)
	if err1 != nil {
		fmt.Println(err1)
		return
	}
	pixel, err2 := image.InspectPixel(2, 0)
	if err2 != nil {
		fmt.Println(err2)
		return
	}
}
