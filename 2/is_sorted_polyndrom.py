"""Matala 3"""

from itertools import pairwise
from typing import Sequence, TypeVar, TypeAlias


T = TypeVar('T')  # No python 3.12
TriSeq: TypeAlias = tuple[Sequence[T], Sequence[T], Sequence[T]]

def seperate(word: Sequence[T], is_odd: bool) -> TriSeq:
    """
    Separates a sequence based on it's length
    uses error based control flow, i dont like it but it's an option
    """
    if is_odd:
        middle = len(word) // 2
        return word[:middle], word[middle + 1:], word[middle]
    middle = len(word) // 2 - 1
    if word[middle] != word[middle+1]:
        raise ValueError
    return word[:middle], word[middle + 2:], word[middle]


def is_sorted_polyndrom(word: str) -> bool:
    """
    Takes a string and checks if its a sorted polyndrom
    uses error based control flow, i dont like it but it's an option
    """
    try:
        left, right, acc = seperate(word, len(word) % 2 != 0)
    except ValueError:
        return False
    if left != right[::-1]:
        return False
    for a, b in pairwise(left + acc): # ABCD -> AB BC CD
        if a >= b:
            return False
    return True
