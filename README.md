# MasterMind
a C# console application that is a simple version of Mastermind.
The randomly generated answer should be four (4) digits in length, with each digit ranging from 1 to 6. After the player enters a combination, a minus (-) sign should be printed for every digit that is correct but in the wrong position, and a plus (+) sign should be printed for every digit that is both correct and in the correct position. Print all plus signs first, all minus signs second, and nothing for incorrect digits. The player has ten (10) attempts to guess the number correctly before receiving a message that they have lost.

Things to know when trying to play:
The user must enter 4 digits of numbers 1-6 to be considered a valid guess. If the guess is invalid an attempt is lost.
If a digit(#) in the users guess is correct in the correct position "[ # ] : +" will be printed for that digit.
If a digit(#) in the users guess is correct in the wrong position "[ # ] : -" will be printed for that digit.

Test Cases for Input:
Null/ Empty input                             - Invalid,
2 Number input(20)                            - Invalid,
3 Number input(301)                           - Invalid,
4 Number input(4555)                          - Valid,
4 Number input number out of range(1-6)(7123) - Invalid,
Random letters (a, aa, ajkk, aaihq)           - Invalid,
5 number input(12345)                         - Invalid,
