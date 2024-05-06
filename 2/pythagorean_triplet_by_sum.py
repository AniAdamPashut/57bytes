import math

def is_pytha_triple(a: int, b: int) -> int | None:
    c2 = a * a + b * b
    if math.sqrt(c2).is_integer():
        return int(math.sqrt(c2))
    return None

def pythagorean_triplet_by_sum(target: int) -> tuple[int, int, int]:
    for i in range(1, target):
        for j in range(1, target):
            c = is_pytha_triple(i, j)
            if c is None:
                continue
            if i + j + c == target and i < j:
                print(f'{i} < {j} < {c}')


if __name__ == '__main__':
    pythagorean_triplet_by_sum(12) # 3 4 5
    pythagorean_triplet_by_sum(24) # 6 8 10
    pythagorean_triplet_by_sum(30) # 5 12 13