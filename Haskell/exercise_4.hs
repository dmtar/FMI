sumDigits input
 |input == 0     = 0
 |input > 0      = y
  where y = sumDigits(div input 10) + (mod input 10)

numDivisors n = d n n

-- d n k = number of divisors of n which are in [1;k] 
d n k
 | k == 1       = 1
 | mod n k == 0 = x + 1
 | otherwise    = x
   where x = d n (k - 1)

--prime n = if numDivisors n == 2 then True else False
prime n = numDivisors n == 2

sumDivisors n = s n (n-1) 0

s n k sum
 | k == 1       = sum + 1
 | mod n k == 0 = s n (k-1) (sum + k)
 | otherwise    = s n (k-1) sum

perfect n = n == sumDivisors n

len l
 | null l     = 0
 | otherwise  = len (tail l) + 1

len2 l = if (null l) then 0 else len2 (tail l) + 1

len3 []    = 0
len3 (_:l) = len3 l + 1

fact 0 = 1
fact n = n * fact (n-1)

{-
binom n 0 = 1
binom n 1 = n
binom n k = ....
-}

-- isElem x l = check if x is an element of l

isElem x l
 | null l      = False
 | head l == x = True
 | otherwise   = isElem x (tail l)

isElem2 _ []    = False
isElem2 x (y:l)
 | x == y    = True
 | otherwise = isElem2 x l