using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using MudBlazor;
using System.Runtime.CompilerServices;

namespace SudokuApp.Components
{
    public partial class SudokuInput
    {
        [Parameter] public EventCallback<int> Input { get; set; }
        [Parameter] public EventCallback CheckSudokuBoard { get; set; }

        public void ButtonHandler(int v)
        {
            this.InputHandler(v);
        }

        public void KeyboardEventHandler(KeyboardEventArgs args)
        {
            int inputValue;

            if (args.Key == "Backspace")
            {
                inputValue = 0;
            }
            else
            {
                switch (args.Key)
                {
                    case "0": case "1": case "2": case "3": case "4": case "5": case "6": case "7": case "8": case "9":
                        inputValue = Int32.Parse(args.Key);
                        break;
                    default:
                        inputValue = -1;
                        break;
                }
            }
            if (inputValue >= 0)
            {
                this.InputHandler(inputValue);
            }
        }

        public async void InputHandler(int v)
        {
            await Input.InvokeAsync(v);
            //SudokuBoard.InputHandler(v);
        }

        public async void CheckSudoku()
        {
            await CheckSudokuBoard.InvokeAsync();
        }
    }
}