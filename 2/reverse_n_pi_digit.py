import math

# readable version
def reverse_n_pi_digits_readable(n: int) -> int:
    def inner(curr, i):
        if curr > 0:
            return str(curr % 10) + inner(curr // 10, i - 1)
        return ''
    return inner(int(math.pi * (10 ** n)), n)

# 3-liner
def reverse_n_pi_digits(n: int) -> str:
    def inner(curr, i): # where is my tail call opt??
        return str(curr % 10) + inner(curr // 10, i - 1) if curr > 0 else ''
    return inner(int(math.pi * (10 ** n)), n)

if __name__ == '__main__':
    print(reverse_n_pi_digits(10))
    print(reverse_n_pi_digits(100))
    