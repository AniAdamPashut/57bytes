# This is basic recursion. no support for tail call
def num_len(number: int) -> int:
    return 0 if number == 0 else 1 + num_len(number // 10)

import math

def num_len(number: int) -> int:
    return math.ceil(math.log10(number)) + 1