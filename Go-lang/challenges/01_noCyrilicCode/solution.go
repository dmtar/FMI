package main

import "fmt"

func hasOnlyLatinSymbols(temp string) bool {
	for i := 0; i < len(temp); i++ {
		if temp[i] > 127 {
			return false
		}
	}
	return true
}
func main() {
	fmt.Println(hasOnlyLatinSymbols(`
    package main

    import "fmt"

    func main() {
         тест:= 12
    }
`))
}