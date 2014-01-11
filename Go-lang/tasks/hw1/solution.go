package main

import (
	"fmt"
	"strings"
)

func pushEmptyCellsToTheEnd(pString []string) []string {
	for i := 0; i < len(pString); i++ {
		if pString[i] == "" {
			for j := i; j < len(pString)-1; j++ {
				temp := pString[j]
				pString[j] = pString[j+1]
				pString[j+1] = temp
			}
			i--
		}
	}
	return pString
}
func parsePath(inputString string) string {
	emptyCellCounter := 0
	cellsArray := strings.SplitN(inputString, "/", strings.Count(inputString, "/")+1)
	fmt.Printf("%v \n", cellsArray)
	cellsArray = pushEmptyCellsToTheEnd(cellsArray)
	for cellIndex := 0; cellIndex < len(cellsArray); cellIndex++ {
		if cellsArray[cellIndex] == ".." || cellsArray[cellIndex] == "." {
			tempCell := cellsArray[cellIndex]
			cellsArray[cellIndex] = ""
			emptyCellCounter++
			if cellIndex-1 >= 0 && cellsArray[cellIndex-1] != ".." && tempCell == ".." {
				cellsArray[cellIndex-1] = ""
				emptyCellCounter++
			}
			cellIndex = -1
		}
	}
	cellsArray = pushEmptyCellsToTheEnd(cellsArray)
	fmt.Printf("%v \n", cellsArray)
	parsedString := strings.Join(cellsArray[0:len(cellsArray)-emptyCellCounter], "/")
	println(parsedString)
	if parsedString == "" {
		return "/"
	} else {
		return "/" + parsedString + "/"
	}
}
