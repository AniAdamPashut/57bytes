def num_len(number: int) -> int:
    return 0 if number == 0 else 1 + num_len(number // 10)
