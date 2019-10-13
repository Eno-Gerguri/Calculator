using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Display_Text_Handler : MonoBehaviour
{
    private string first_number = "None";
    private string math_operator;
    private string second_number;
    private bool have_done_calculation = false;

    #region Get Displays

    private TextMeshProUGUI Main_Display_Text;
    private TextMeshProUGUI Sub_Display_Text;

    private void Start()
    {
        Main_Display_Text = GameObject.Find("Main_Display_Text").GetComponent<TextMeshProUGUI>();
        Sub_Display_Text = GameObject.Find("Sub_Display_Text").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (Main_Display_Text.text == "")
        {
            Main_Display_Text.text = "0";
        }
    }

    #endregion

    #region Number Clicked

    private string current_typed_number;

    public void Number_Button_Click(GameObject number_being_pressed)  // If a number is clicked
    {
        if (Main_Display_Text.text == "0")  // Replace the 0
        {
            Main_Display_Text.text = "";
        }

        if (have_done_calculation)  // Reset all variables and displays
        {
            Main_Display_Text.text = number_being_pressed.GetComponent<TextMeshProUGUI>().text;
            Sub_Display_Text.text = "";
            first_number = "None";
            second_number = null;
            math_operator = null;
        }
        else
        {
            Main_Display_Text.text = Main_Display_Text.text + number_being_pressed.GetComponent<TextMeshProUGUI>().text;  // Add number to Main Display

            current_typed_number = Main_Display_Text.text;
        }
    }

    #endregion

    #region Math Symbol Clicked

    public void Math_Symbol_Click(GameObject math_symbol_pressed)  // If a symbol is clicked
    {
        
        if (first_number == "None")
        {
            first_number = Main_Display_Text.text;
        }

        if (math_symbol_pressed.name == "Divide Button")
        {
            math_operator = "/";
        }
        else if (math_symbol_pressed.name == "Multiply Button")
        {
            math_operator = "*";
        }
        else if (math_symbol_pressed.name == "Minus Button")
        {
            math_operator = "-";
        }
        else if (math_symbol_pressed.name == "Add Button")
        {
            math_operator = "+";
        }

        Sub_Display_Text.text = Sub_Display_Text.text + current_typed_number + math_operator;
        Main_Display_Text.text = "";
    }

    #endregion

    #region Equals Button Clicked

    public void equals_button_clicked()
    {
        second_number = Main_Display_Text.text;

        Single num_1 = Single.Parse(first_number);
        Single num_2 = Single.Parse(second_number);

        switch(math_operator)
        {
            case "/":
                Main_Display_Text.text = (num_1 / num_2).ToString();
                break;

            case "*":
                Main_Display_Text.text = (num_1 * num_2).ToString();
                break;

            case "+":
                Main_Display_Text.text = (num_1 + num_2).ToString();
                break;

            case "-":
                Main_Display_Text.text = (num_1 - num_2).ToString();
                break;

            default:
                break;
        }

        first_number = Main_Display_Text.text;
    }

    #endregion
}
