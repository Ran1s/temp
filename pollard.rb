def gcd_euclid(a, b)
    while a > 0 and b > 0
        if a < b
            a, b = b, a
        end
        a %= b
    end
    a + b
end

def f(b)
    primes = []
    primes << 2
    i = 0;
    num = 3
    ok = true
    while primes[i]**2 < num
        if num % primes[i]
            ok = false
        end
        i += 1
    end
end

def pollard1(n, b)
    
end

a, b = gets.chomp.split.map(&:to_i)
p gcd_euclid a, b
