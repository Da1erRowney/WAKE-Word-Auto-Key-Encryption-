# 🔐 WAKE Encryption Algorithm Implementation

This code implements the **WAKE** encryption algorithm based on a bitwise exclusive OR (XOR) operation in a Windows Forms application.

## 🖥️ Form Interface

The application features a user-friendly interface with the following components:

- **Text Fields**:
  - `textBox1`: (Unused)
  - `textBox2`: Displays the ciphertext.
  - `textBox3`: Displays the decrypted text.
  - `textBox4`: (Unused)
  - `textBox5`: Input for the encryption key.
  - `textBox6`: Input for plaintext.
  - `textBox7`: (Unused)

- **Buttons**:
  - Button for performing encryption.
  - Button for performing decryption.

- **Data Grid View**:
  - `dataGridView1`: Displays results including ASCII character codes, ASCII key codes, and ASCII encrypted character codes.

## 🔒 Encryption Process

1. **User Input**: The user enters the plaintext in `textBox6` and the key in `textBox5`.
2. **Conversion**: The plaintext and key are converted to ASCII numeric sequences using the `GetHexNumericSequence` method.
3. **Encryption**: Each plaintext character is XOR'd with the corresponding key character to produce the ciphertext.
4. **Display**: The ciphertext is displayed in `textBox2`, and the calculation results are shown in `dataGridView1`.

## 🔓 Decryption Process

1. **User Input**: The user enters the ciphertext in `textBox2` and the key in `textBox5`.
2. **Conversion**: The ciphertext and key are converted into numeric sequences of ASCII codes.
3. **Decryption**: Each character in the ciphertext is XOR'd with the corresponding key character to recover the original plaintext.
4. **Display**: The decrypted text is displayed in `textBox3`.

## 🔢 GetHexNumericSequence Method

This method converts a string into a numeric sequence of ASCII codes. It loops through each character in the string and converts them into their corresponding numeric values in hexadecimal format.

## 🔍 Example of Work

Here’s an example of the application's output:

<div align="center">
  <img src="https://github.com/Da1erRowney/WAKE-Word-Auto-Key-Encryption-/assets/126601293/cd3b6a3c-de3a-465a-8b4c-67b5e59ac26c" alt="Example of Work" width="500"/>
</div>

## 📚 Conclusion

This code implements a simple WAKE-based encryption and decryption algorithm that can be used to protect data from unauthorized access. The straightforward approach ensures ease of use while maintaining data security.
