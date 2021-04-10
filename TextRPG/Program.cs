using System;
using System.IO;
using System.Reflection;

namespace TextRPG {
    class Program {
        static void Main(string[] args) {
            /// Console.WriteLine("Hello World!");
            /// 게임의 기본 구조

            GameManager Game = new GameManager();

            SaveManager.Save.Init();

            Console.WriteLine("Initialization Complete!");

            while (Game.life) {
                Game.Game();
            }
            
            return;
        }
    }

    class SaveData {
        public int hp = 100, maxHp = 100, xp = 0, maxXp = 100, place = 0, lv = 1;
        public string name = "unknown";
        public bool isDead = false;

        public SaveData() {
            if (File.Exists(@"Save.ini")) {
                string[] lines = File.ReadAllLines(@"Save.ini");
                foreach (string line in lines) {
                    string[] param = line.Split('=');
                    FieldInfo field = this.GetType().GetField(param[0]);

                    switch(field.FieldType.ToString()) {
                        case "System.Int32":
                            field.SetValue(this, Int32.Parse(param[1]));
                            break;

                        case "System.Boolean":
                            field.SetValue(this, Boolean.Parse(param[1]));
                            break;

                        case "System.String":
                            field.SetValue(this, param[1]);
                            break;

                        default:
                            Console.WriteLine("I got new type \"{0}\" here", field.FieldType.ToString());
                            break;
                    }
                }
                Console.WriteLine("저장 내역을 불러왔습니다.");
            } else {
                string[] savings = new string[8];
                System.Reflection.FieldInfo[] values = this.GetType().GetFields();
                for (int i = 0; i < savings.Length; i++) {
                    savings[i] = values[i].Name.ToString() + "=" + values[i].GetValue(this).ToString();
                }
                File.WriteAllLines(@"Save.ini", savings);
                Console.WriteLine("새로운 저장 파일을 생성했습니다.");
            }
        }

        public void Init() { }
    }

    class SaveManager {
        private static SaveData instance = null;

        public static SaveData Save {
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
        public bool life = true;
        /** current scene
         * 0: 메인 메뉴
         * 1: 태초 마을
         */
        int scene = 0;

        public void Game() {
            switch (scene) {
                case 0:
                    MainMenu();
                    break;

                case 1:
                    GamePlay();
                    break;

                case 2:
                    Options();
                    break;
            }
        }

        /// <summary>
        /// 메인 메뉴 함수
        /// </summary>
        private void MainMenu() {
            Console.Clear();
            Console.WriteLine("[메인 메뉴]\n1.게임 시작\n2.옵션\n3.종료\n\n────────────────────\n[입력]");
            string read = Console.ReadLine();
            switch (read) {
                case "1":
                    scene = 1;
                    break;

                case "2":
                    scene = 2;
                    break;

                case "3":
                    life = false;
                    break;

                default:
                    break;
            }
        }

        private void GamePlay() {
            Console.Clear();
            Console.WriteLine("[Text RPG]");
            switch (SaveManager.Save.place) {
                case 0:     /// 태초 마을
                    
                    break;
            }
        }

        private void Options() {
            Console.Clear();
            Console.WriteLine("[Options]\n1.뒤로가기\n\n────────────────────\n[입력]");
            string read = Console.ReadLine();
            switch (read) {
                case "1":
                    scene = 0;
                    break;

                default:
                    break;
            }
        }
    }
}
