﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WakeEncryption
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string encryptedText = textBox2.Text;

            string key = textBox5.Text;

            List<int> encryptedNumeric = GetHexNumericSequence(encryptedText);
            List<int> keyNumeric = GetHexNumericSequence(key);

            List<int> decryptedNumeric = new List<int>();
            for (int i = 0; i < encryptedNumeric.Count; i++)
            {
                int decryptedChar = encryptedNumeric[i] ^ keyNumeric[i % keyNumeric.Count];
                decryptedNumeric.Add(decryptedChar);
            }

            StringBuilder decryptedText = new StringBuilder();
            foreach (int num in decryptedNumeric)
            {
                decryptedText.Append((char)num);
            }

            textBox3.Text = decryptedText.ToString();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;

            StringBuilder hexadecimalResult = new StringBuilder();
            foreach (char c in inputText)
            {
                string hexValue = ((int)c).ToString("X2");

                hexadecimalResult.Append(hexValue);
            }

            textBox4.Text = hexadecimalResult.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string key = textBox4.Text;

            if (key.Length < 16)
            {
                MessageBox.Show($"Enter a key of at least 16 characters. / Введите ключ длиной не менее16 символов. ");
                return;
            }

            string part1 = key.Substring(0, 8);
            string part2 = key.Substring(8, 8);
            string part3 = key.Substring(16, 8);
            string part4 = key.Substring(24, 8);

            string[] registers = new string[4];
            registers[0] = part1;
            registers[1] = part2;
            registers[2] = part3;
            registers[3] = part4;

            richTextBox1.Clear();
            richTextBox1.AppendText($"R3[0]={registers[0]} ");
            richTextBox1.AppendText($"R4[0]={registers[1]} ");
            richTextBox1.AppendText($"R5[0]={registers[2]} ");
            richTextBox1.AppendText($"R6[0]={registers[3]} ");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] registers = richTextBox1.Lines[0].Split(' ');

            string R3 = registers[0].Split('=')[1];
            string R4 = registers[1].Split('=')[1];
            string R5 = registers[2].Split('=')[1];
            string R6 = registers[3].Split('=')[1];

            string R3_next = CalculateNextValue(R3, R6);
            string R4_next = CalculateNextValue(R4, R3_next);
            string R5_next = CalculateNextValue(R5, R4_next);
            string R6_next = CalculateNextValue(R6, R5_next);

            string newKey = R6_next;

            textBox5.Text = newKey;
        }

        private string CalculateNextValue(string R, string prevR)
        {
            int R_decimal = Convert.ToInt32(R, 16);
            int prevR_decimal = Convert.ToInt32(prevR, 16);

            int sum = R_decimal + prevR_decimal;
            int S_index = sum & 255; 
            int S_value = GetSValue(S_index);
            int result = (sum >> 8) ^ S_value;

            return result.ToString("X8");
        }


        private int GetSValue(int index)
        {
            int[] sBlock = {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
                0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F,
                0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
                0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F,
                0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F,
                0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A, 0x5B, 0x5C, 0x5D, 0x5E, 0x5F,
                0x60, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6A, 0x6B, 0x6C, 0x6D, 0x6E, 0x6F,
                0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 0x78, 0x79, 0x7A, 0x7B, 0x7C, 0x7D, 0x7E, 0x7F,
                0x80, 0x81, 0x82, 0x83, 0x84, 0x85, 0x86, 0x87, 0x88, 0x89, 0x8A, 0x8B, 0x8C, 0x8D, 0x8E, 0x8F,
                0x90, 0x91, 0x92, 0x93, 0x94, 0x95, 0x96, 0x97, 0x98, 0x99, 0x9A, 0x9B, 0x9C, 0x9D, 0x9E, 0x9F,
                0xA0, 0xA1, 0xA2, 0xA3, 0xA4, 0xA5, 0xA6, 0xA7, 0xA8, 0xA9, 0xAA, 0xAB, 0xAC, 0xAD, 0xAE, 0xAF,
                0xB0, 0xB1, 0xB2, 0xB3, 0xB4, 0xB5, 0xB6, 0xB7, 0xB8, 0xB9, 0xBA, 0xBB, 0xBC, 0xBD, 0xBE, 0xBF,
                0xC0, 0xC1, 0xC2, 0xC3, 0xC4, 0xC5, 0xC6, 0xC7, 0xC8, 0xC9, 0xCA, 0xCB, 0xCC, 0xCD, 0xCE, 0xCF,
                0xD0, 0xD1, 0xD2, 0xD3, 0xD4, 0xD5, 0xD6, 0xD7, 0xD8, 0xD9, 0xDA, 0xDB, 0xDC, 0xDD, 0xDE, 0xDF,
                0xE0, 0xE1, 0xE2, 0xE3, 0xE4, 0xE5, 0xE6, 0xE7, 0xE8, 0xE9, 0xEA, 0xEB, 0xEC, 0xED, 0xEE, 0xEF,
                0xF0, 0xF1, 0xF2, 0xF3, 0xF4, 0xF5, 0xF6, 0xF7, 0xF8, 0xF9, 0xFA, 0xFB, 0xFC, 0xFD, 0xFE, 0xFF
            };


            if (index < 0 || index >= sBlock.Length)
            {
                throw new ArgumentException("The index is out of range of the array. / Индекс находится вне диапазона массива.");
            }

            return sBlock[index];
        }

        private void button6_Click(object sender, EventArgs e)
        {

            string inputText = textBox6.Text;

            StringBuilder hexadecimalResult = new StringBuilder();
            foreach (char c in inputText)
            {
                string hexValue = ((int)c).ToString("X2"); 

                hexadecimalResult.Append(hexValue);
            }

            textBox7.Text = hexadecimalResult.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string plaintext = textBox6.Text;

            string key = textBox5.Text;

            List<int> plaintextNumeric = GetHexNumericSequence(plaintext);
            List<int> keyNumeric = GetHexNumericSequence(key);

            List<int> encryptedNumeric = new List<int>();
            for (int i = 0; i < plaintextNumeric.Count; i++)
            { 
                int encryptedChar = plaintextNumeric[i] ^ keyNumeric[i % keyNumeric.Count];
                encryptedNumeric.Add(encryptedChar);
            }

            StringBuilder encryptedText = new StringBuilder();
            foreach (int num in encryptedNumeric)
            {
                encryptedText.Append((char)num);
            }

            textBox2.Text = encryptedText.ToString();

            dataGridView1.Rows.Clear();
            for (int i = 0; i < plaintext.Length; i++)
            {
                dataGridView1.Rows.Add(i + 1, plaintext[i], plaintextNumeric[i], keyNumeric[i % keyNumeric.Count], encryptedNumeric[i], (char)encryptedNumeric[i]);
            }
        }

        private List<int> GetHexNumericSequence(string input)
        {
            List<int> numericSequence = new List<int>();
            foreach (char c in input)
            {
                int charValue = (int)c;
                numericSequence.Add(charValue);
            }
            return numericSequence;
        }
    }
}
