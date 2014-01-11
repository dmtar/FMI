fact1 n = if n == 0 then 1 else n * fact1 (n-1)

--fact2 :: Int -> Int
fact2 n
 | n == 0    = 1
 | otherwise = n * fact2 (n-1)


--fact3 :: Integer -> Integer
fact3 n = cycle 1 1
  where cycle i result
         | i <= n     = cycle (i + 1) (result * i)
         | otherwise  = result

{-

int fact(int n) {
  int result = 1;
  for(int i = 1; i <= n; i++)
    result *= i;
  return result;
}

-}


pow1 x n
  | n == 0 = 1
  | n > 0  = x * pow1 x (n-1)
  | n < 0  = 1 / pow1 x (-n)

pow2 x n = cycle 1 1
  where cycle i result
         | i <= abs n = cycle (i + 1) (result * x)
         | otherwise  = if n > 0 then result else 1/result

repeatme k pow x n
  | k == 0                = "stop"
  | k > 0 && pow x n > 0  = repeatme (k-1) pow x n
  | otherwise             = "this should not happen!"


qpow x n
  | n == 0     = 1
  | n < 0      = 1 / qpow x (-n)
  | even n     = y * y
  | otherwise  = x * qpow x (n - 1)
   where y = qpow x (div n 2)

-- repeatme 1000 pow1 2 1000
-- repeatme 1000 pow2 2 1000
-- repeatme 1000 qpow 2 1000
