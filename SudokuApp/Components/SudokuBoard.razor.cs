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
    public partial class SudokuBoard
    {
        [Parameter]
        public string Givens { get; set; }
        [Parameter]
        public int Width { get; set; }
        [Parameter]
        public int Height { get; set; }

        private bool _initialised;
        private List<int> _givens;

        public List<SudokuSquare> sudokuSquares;

        protected override async Task OnInitializedAsync()
        {
            int squareCount = (this.Width * this.Height);
            if (!this._initialised)
            {
                _givens = new List<int>();

                if (!String.IsNullOrEmpty(Givens))
                {
                    foreach (char c in Givens)
                    {
                        try
                        {
                            _givens.Add(Int32.Parse(c.ToString()));
                        }
                        catch
                        {
                            _givens.Add(0);
                        }
                    }
                }

                if (_givens.Count != squareCount)
                {
                    for (int i = _givens.Count - 1; i < squareCount; i++)
                    {
                        _givens.Add(0);
                    }
                }

                sudokuSquares = new List<SudokuSquare>();
                for (int i = 0; i < squareCount; i++)
                {
                    sudokuSquares.Add(new SudokuSquare());
                }
                
                this._initialised = true;
            }
        }

        public void KeyboardEventHandler(KeyboardEventArgs args)
        {
            foreach (SudokuSquare square in sudokuSquares)
            {
                if (square.IsSelected)
                {
                    square.KeyboardEventHandler(args);
                }
            }
        }

        public void SquareClicked(MouseEventArgs args)
        {
            if (!args.CtrlKey)
            {
                foreach (SudokuSquare square in sudokuSquares)
                {
                    square.IsSelected = false;
                }
            }
        }

        public void CheckValues()
        {
            bool conflict;
            foreach (SudokuSquare square in sudokuSquares)
            {
                conflict = false;
                foreach (SudokuSquare checkSquare in sudokuSquares)
                {
                    if(square.Row == checkSquare.Row || square.Column == checkSquare.Column || square.Group == checkSquare.Group)
                    {
                        if (square.Value == checkSquare.Value && square.Value != 0 && square != checkSquare)
                        {
                            conflict = true;
                        }
                    }
                }
                if (square.Value == 0)
                {
                    square.ErrorState = SquareErrorState.NotChecked;
                }
                else
                {
                    if (conflict)
                    {
                        square.ErrorState = SquareErrorState.Error;
                    }
                    else
                    {
                        square.ErrorState = SquareErrorState.Safe;
                    }
                }
            }
        }
        
    }
}