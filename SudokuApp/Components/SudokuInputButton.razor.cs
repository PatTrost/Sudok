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
    public partial class SudokuInputButton
    {
        [Parameter] public EventCallback<int> Clicked { get; set; }
        [Parameter] public int Value { get; set; }

        public static string GetButtonStyle()
        {
            return "width: 73px; height: 73px;";
        }

        public static string GetTextStyle()
        {
            return "font-size: 40px;";
        }
        public static string GetStyle()
        {
            return "width: 75px; height: 75px;";
        }

        public async void OnClick(MouseEventArgs args)
        {
            await Clicked.InvokeAsync(Value);
        }
    }
}