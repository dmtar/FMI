package main

import "fmt"

type DragonFractal struct {
	allSteps              []string
	timesCalledMethodNext int
}

func reverse(input []string) []string {
	for i, j := 0, len(input)-1; i < j; i, j = i+1, j-1 {
		input[i], input[j] = input[j], input[i]
	}
	return input
}

func (d *DragonFractal) push(item string) {
	for i := range d.allSteps {
		if d.allSteps[i] == "" {
			d.allSteps[i] = item
			break
		}
	}
}

func (d *DragonFractal) countElements() int {
	count := 0
	for i := range d.allSteps {
		if d.allSteps[i] != "" {
			count++
		}
	}
	return count
}

func (d *DragonFractal) generateSteps() {

	var nextRotation []string
	if len(d.allSteps) == 0 {
		d.allSteps = make([]string, 1)
		d.allSteps[0] = "up"
	} else {
		nextRotation = append(nextRotation, d.allSteps...)
		if d.countElements() > len(d.allSteps)/2 {
			t := make([]string, len(d.allSteps)*2)
			copy(t, d.allSteps)
			d.allSteps = t
		}
		for i := range nextRotation {
			switch nextRotation[i] {
			case "up":
				nextRotation[i] = "left"
			case "left":
				nextRotation[i] = "down"
			case "right":
				nextRotation[i] = "up"
			case "down":
				nextRotation[i] = "right"
			}
		}
		nextRotation = reverse(nextRotation)
		for i := range nextRotation {
			d.push(nextRotation[i])
		}
	}
}

func (d *DragonFractal) Next() {
	d.timesCalledMethodNext++
	if d.timesCalledMethodNext > len(d.allSteps)/2 {
		d.generateSteps()
	}
	fmt.Println(d.allSteps[d.timesCalledMethodNext-1])
}

func main() {
	test := new(DragonFractal)
	test.Next()
	test.Next()
	test.Next()
	test.Next()
	test.Next()
	test.Next()
	test.Next()
	test.Next()

}
