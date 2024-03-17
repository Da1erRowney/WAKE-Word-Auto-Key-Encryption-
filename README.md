The code implements the WAKE encryption algorithm based on a bitwise exclusive OR (XOR) operation.

Form Interface: This code is written for a Windows Forms application. The form has several text fields (textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7) for entering text and key, buttons for performing encryption and decryption operations, and a dataGridView1 control for displaying the results.

Encryption:
The user enters the plaintext (textBox6) and the key (textBox5).
The plaintext and key are converted to ASCII numeric sequences using the GetHexNumericSequence method.
Each plaintext character is then encrypted by bitwise XOR with the corresponding key character.
The ciphertext is displayed in textBox2, and the calculation results (ASCII character codes, ASCII key codes, ASCII encrypted character codes) are displayed in dataGridView1.

Decryption:
The user enters the ciphertext (textBox2) and the key (textBox5).
The ciphertext and key are also converted into numeric sequences of ASCII codes.
Each ciphertext character is decrypted by bitwise XOR with the corresponding key character.
The decrypted text is displayed in textBox3.

GetHexNumericSequence method:
This method converts a string into a numeric sequence of ASCII codes. It simply loops through the characters in a string and converts them into numeric values represented in hexadecimal.
Encryption type:

In this case, WAKE-based encryption is used.
During the encryption process, each plaintext character is XOR'd with the corresponding key character. This results in the ciphertext being obtained.
During decryption, the same operation occurs: each character in the ciphertext is XORed with a character in the key to recover the original plaintext.
Thus, this code implements a simple WAKE-based encryption and decryption algorithm that can be used to protect data from unauthorized access.

URL - https://ru.wikipedia.org/wiki/WAKE

Example of work:
![image](https://github.com/Da1erRowney/WAKE-Word-Auto-Key-Encryption-/assets/126601293/cd3b6a3c-de3a-465a-8b4c-67b5e59ac26c)
