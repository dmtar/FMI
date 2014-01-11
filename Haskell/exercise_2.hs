numDevisors1 n = cycle 1 0
 where cycle i result
        |i<=n && (mod n i)==0 = cycle (i+1) (result+1)
        |i>n                  = result
        |otherwise            = cycle (i+1) (result)

numDevisors n = d n n

d n k
 | k==1        = 1
 | mod n k ==0 = x + 1
 | otherwise   = x
   where x = d n (k-1)

prime n = if numDevisors n == 2 then True else False

perfect n = if ((cycle 1 0)==n) then True else False
 where cycle i result
        |i<n && (mod n i)==0 = cycle (i+1) (result+i)
        |i>=n                  = result
        |otherwise            = cycle (i+1) result

len l
 | null []   = 0
 | otherwise = len (tail l) +1

len2 []=0
len2 (_:l) = len2 l + 1

-- isElem x l = check if x is element of l

isElem x l
 | null l      = False
 | head l == x = True
 | otherwise   = isElem x (tail l)

isElem2 _ []    = False
isElem2 x (y:l)  
 | x==y      = True
 | otherwise = isElem2 x l