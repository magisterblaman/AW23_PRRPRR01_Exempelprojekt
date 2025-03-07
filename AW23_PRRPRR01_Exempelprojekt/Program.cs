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

		static void AddPiece(int piece, int col) {

			for (int r = board.GetLength(1) - 1; r >= 0; r--) {
				if (board[col, r] == 0) {
					board[col, r] = piece;
					return;
				}
			}
		}

		static void CommandSystem() {
			Console.Write("Vänligen ange ett kommando: ");
			string command = Console.ReadLine().Trim();

			string[] commandTokens = command.Split(' ');

			if (commandTokens[0] == "piece") {

				if (commandTokens[1] == "put") {

					int column = int.Parse(commandTokens[2]);

					AddPiece(currentPlayer, column);

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
