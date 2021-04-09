using System;
using System.IO;

namespace TextRPG {
    class Program {
        public SaveData data = new SaveData();

        static void Main(string[] args) {
            /// Console.WriteLine("Hello World!");
            /// 게임의 기본 구조
            bool life = true;   /// life of the game

            /** current scene
             * 0: 메인 메뉴
             * 1: 태초 마을
             */
            int scene = 0;

            while (life) {
                GameManager.Instance.Game(scene);
            }
        }
    }

    class SaveData {
        public int hp, maxHp, xp, maxXp, place, lv;
        public string name;
        public bool isDead;

        public SaveData() {
            if (File.Exists(@"Save.txt")) {
                string[] lines = File.ReadAllLines(@"Save.txt");
                foreach (string line in lines) {

                }
            } else {

            }
        }
    }

    class SaveSingleTone {
        private SaveSingleTone() { }
        private static SaveData instance = null;

        public static SaveData Instance {
            get {
                if (instance == null) instance = new SaveData();
                return instance;
            }
        }
    }

    class Player {
        /**@function
         * constructor
         */
        public Player() {

        }

        public void Initialize(int lv) {

        }

    }

    class GameManager {
        private GameManager() { }
        private static GameManager instance = null;

        public static GameManager Instance {
            get {
                if (instance == null) instance = new GameManager();
                return instance;
            }
        }

        public void Game(int scene) {
            switch (scene) {
                case 0:
                    MainMenu();
                    break;

                case 1:
                    break;
            }
        }

        /// <summary>
        /// 메인 메뉴 함수
        /// </summary>
        private void MainMenu() {

        }
    }
}
