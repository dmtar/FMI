dfact::Integer->Integer
dfact 0 = 1
dfact n = n*dfact (n-2)

hasDigit::Integer->Integer->Bool
hasDigit n f
 | n<10 && n/=f  = False
 | mod n 10 == f = True
 | otherwise     = hasDigit k f
  where k = div n 10

listDigits::Integer->[Integer]
listDigits n
 |n<10 =[n]
 |otherwise = listDigits m ++ [k]
  where k= mod n 10
        m= div n 10 

listDigits2::Integer->[Integer]
listDigits2 n
 |n<10 =[n]
 |otherwise = [k] ++ listDigits2 m
  where k= mod n 10
        m= div n 10 
		
listDevisors::Integer->[Integer]
listDevisors n = cycle1 n n
 
cycle1::Integer->Integer->[Integer]
cycle1 n k
 | k==0        = []
 | mod n k ==0 = k:cycle1 n (k-1)
 | otherwise   = cycle1 n (k-1)
 
intersect y [] = [] 
intersect [] y = []
intersect (x:xs) (y:ys)
 | elem x (y:ys) = x:intersect xs (y:ys)
 | otherwise     = intersect xs (y:ys)

diag::[[Integer]]->[Integer]
diag []    = []
diag (h:t) = head(h):diag[tail x | x<-t]


diag2::[[Integer]]->[Integer]
diag2 l =[head x | x<-l]


getElemAt x i= head(drop i x)
dropElemAt x i= (take i x) ++ (drop (i+1) x)

getColumn m i=[(getElemAt x i) | x<-m]
removeColumn m i = [(dropElemAt x i) | x<-m]

countOcc::(Eq a)=>[a]->a->Integer
countOcc [] a     = 0
countOcc (x:xs) a = cycle3 (x:xs) a 0
cycle3 (x:xs) a b
 |xs==[] && x/=a     = b
 |xs==[] && x==a     = b+1
 |x==a               = cycle3 xs a (b+1)
 |otherwise          = cycle3 xs a b

unique::(Eq a)=>[a]->[a]
unique l = cycle4 l

cycle4 [] = []
cycle4 (x:xs)
 |elem x xs = cycle4 (deleteElem (x:xs) x)
 |otherwise = x:cycle4 xs
 
deleteElem [] f = []
deleteElem (x:xs) f
 |f==x       = deleteElem (xs) f
 |otherwise  =  x:deleteElem xs f
 
setsEqual l1 l2
 |unique (l1++l2) /= [] = False
 |otherwise             = True
 
countValues::[Integer]->Integer
countValues [] = 0
countValues (x:xs) = cycle5 (x:xs) 0

check1::Integer->Integer->Bool
check1 a b
 |a==b       = True
 |otherwise  = False

cycle5 [] a = 0
cycle5 (x:xs) a
 |check1 x (countOcc (x:xs) x) = cycle5 xs a+1
 |otherwise                    = cycle5 xs a
