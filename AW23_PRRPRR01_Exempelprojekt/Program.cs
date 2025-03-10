using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW23_PRRPRR01_Exempelprojekt {
	internal class Program {
		static int[,] board = new int[7, 6];
		static int currentPlayer = 0;

		static void DrawBoard() {
			for (int r = 0; r < board.GetLength(1); r++) {
				for (int c = 0; c < board.GetLength(0); c++) {
					int currentSlot = board[c, r];

					if (currentSlot == 0) {
						Console.Write("[ ]");
					} else if (currentSlot == 1) {
						Console.Write("[X]");
					} else if (currentSlot == 2) {
						Console.Write("[O]");
					}
				}

				Console.WriteLine();
			}
		}

		static int AddPiece(int piece, int col) {

			for (int r = board.GetLength(1) - 1; r >= 0; r--) {
				if (board[col, r] == 0) {
					board[col, r] = piece;
					return r;
				}
			}

			return -1;
		}

		static int CheckForWin(int lastPlacedRow, int lastPlacedCol) {
			int lastPlaced = board[lastPlacedCol, lastPlacedRow];

			int horizontalMatchCounter = 0;
			for (int i = -1; i >= -3; i--) {
				if (lastPlacedCol + i < 0) {
					break;
				}
				if (board[lastPlacedCol + i, lastPlacedRow] == lastPlaced) {
					horizontalMatchCounter++;
				} else {
					break;
				}
			}
			for (int i = 1; i <= 3; i++) {
				if (lastPlacedCol + i >= board.GetLength(0)) {
					break;
				}
				if (board[lastPlacedCol + i, lastPlacedRow] == lastPlaced) {
					horizontalMatchCounter++;
				} else {
					break;
				}
			}
			if (horizontalMatchCounter >= 3) {
				return lastPlaced;
			}

			int verticalMatchCounter = 0;
			for (int i = -1; i >= -3; i--) {
				if (lastPlacedRow + i < 0) {
					break;
				}
				if (board[lastPlacedCol, lastPlacedRow + i] == lastPlaced) {
					verticalMatchCounter++;
				} else {
					break;
				}
			}
			for (int i = 1; i <= 3; i++) {
				if (lastPlaced + i >= board.GetLength(1)) {
					break;
				}
				if (board[lastPlacedCol, lastPlacedRow + i] == lastPlaced) {
					verticalMatchCounter++;
				} else {
					break;
				}
			}
			if (verticalMatchCounter >= 3) {
				return lastPlaced;
			}

			return 0;
		}

		static void CommandSystem() {
			Console.Write("Vänligen ange ett kommando: ");
			string command = Console.ReadLine().Trim();

			string[] commandTokens = command.Split(' ');

			if (commandTokens[0] == "piece") {

				if (commandTokens[1] == "put") {

					int column = int.Parse(commandTokens[2]);

					int row = AddPiece(currentPlayer, column);

					if (row == -1) {
						// Hittade inte
					}

					int win = CheckForWin(row, column);

					if (win == 1) {
						Console.WriteLine("X vann");
						Console.ReadLine();
					} else if (win == 2) {
						Console.WriteLine("O vann");
						Console.ReadLine();
					}
				}

			}
		}

		static void Main(string[] args) {
			currentPlayer = 1;

			while (true) {
				Console.Clear();

				DrawBoard();

				CommandSystem();

				if (currentPlayer == 1) {
					currentPlayer = 2;
				} else {
					currentPlayer = 1;
				}
			}
		}
	}
}
