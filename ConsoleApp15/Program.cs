using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Vuaphanloai
{
    internal class Program
    {
        static Dictionary<string, List<int>> playerScores = new Dictionary<string, List<int>>();
        static string nguoichoi = string.Empty;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            NameGame();

            string message = "Nhấn phím bất kỳ để tiếp tục...";
            Print((Console.BufferWidth - message.Length) / 2,
                  Console.BufferHeight / 2 + 7,
                  message,
                  ConsoleColor.DarkRed);

            Console.ReadKey(true);
            while (true)
            {
                Console.Clear();
                ShowMenu();
            }
        }

        public static void NameGame()
        {
            string[] Name = new string[]
            {
                @" _______   ___                            ___                                      _______                          ",
                @"/ $$$$$ \  $$|                            $$|                             ___     /$$$$$$$\                            ",
                @"$$     $ | $$|                            $$|                            /$$$\    $$      $|                            ",
                @"$$     $$| $$|                            $$|                            \$$$/    $$ $$$$ $|                            ",
                @"$$ $$$ $$| $$|___    ______     ______    $$|        ______     ______    __      $$ _____/    ______      ______   ",
                @"$$ _____/  $$ $$$\  / $$$$$|   /$$$ $$\   $$|       / $$$$ \   / $$$$$|   $$|     $$ | $$$\   / $$$$$|   /$$$$$$/    ",
                @"$$ |       $$ __$| $$$   $$|_   $$__ $|   $$|       $$    $$| $$$   $$|_  $$|     $$ |   $$\ $$$   $$|_  $$  --    ",
                @"$$ |       $$ | $|  $$    $$|$| $$|  $|   $$|____   $$    $$| $$    $$$|$ $$|     $$ |    $$\ $$    $$$| $$$|____   ",
                @"$$ |       $$ | $|   $$$$$$$ /  $$/  $/   $$$$$$$$$  $$$$$ /   $$$$$$$ /  $$|     $$ |      $\ $$$$$$$/   \$$$$$$\   ",
            };

            Print((Console.BufferWidth - Name[0].Length) / 2,
                  Math.Max(0, Console.BufferHeight / 2 - 6),
                  Name,
                  ConsoleColor.DarkGreen);
        }

        public static void Print(int x, int y, string text, ConsoleColor color)
        {
            if (x < 0 || y < 0 || y >= Console.BufferHeight) return;

            Console.SetCursorPosition(Math.Max(0, x), y);
            Console.ForegroundColor = color;
            Console.Write(text.Length > Console.BufferWidth ? text.Substring(0, Console.BufferWidth) : text);
            Console.ResetColor();
        }

        public static void Print(int x, int y, string[] text, ConsoleColor color)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (y + i >= Console.BufferHeight) break;

                string line = text[i].Length > Console.BufferWidth
                              ? text[i].Substring(0, Console.BufferWidth)
                              : text[i];

                Console.SetCursorPosition(Math.Max(0, x), y + i);
                Console.ForegroundColor = color;
                Console.Write(line);
            }
            Console.ResetColor();
        }

        static void ShowMenu()
        {
            Console.Clear();

            // Tính toán vị trí y bắt đầu và x để căn giữa
            int yStart = (Console.BufferHeight - 3) / 2; // 3 dòng menu
            int xStart = (Console.BufferWidth - 73) / 2; // Độ dài chuỗi dài nhất là 73 ký tự

            // Định nghĩa các màu cho từng chức năng
            ConsoleColor[] colors = { ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.Red };

            // In dòng trên cùng của menu
            Console.SetCursorPosition(xStart, yStart);
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━┓   ┏━━━━━━━━━━━━━━━━━┓   ┏━━━━━━━━━━━━━━━━━┓   ┏━━━━━━━━━━━━━━━━━┓");

            // In dòng giữa với từng màu cho chức năng
            Console.SetCursorPosition(xStart, yStart + 1);
            Console.ForegroundColor = colors[0];
            Console.Write("┃ 1. Bắt đầu chơi ┃   ");
            Console.ForegroundColor = colors[1];
            Console.Write("┃  2. Hướng dẫn   ┃   ");
            Console.ForegroundColor = colors[2];
            Console.Write("┃ 3. Cài đặt nhạc ┃   ");
            Console.ForegroundColor = colors[3];
            Console.WriteLine("┃    4. Thoát     ┃");
            Console.ResetColor();

            // In dòng dưới cùng của menu
            Console.SetCursorPosition(xStart, yStart + 2);
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━┛   ┗━━━━━━━━━━━━━━━━━┛   ┗━━━━━━━━━━━━━━━━━┛   ┗━━━━━━━━━━━━━━━━━┛");

            // In lời nhắc nhập lựa chọn bên dưới menu
            string prompt = "Mời bấm phím để lựa chọn: ";
            int promptX = (Console.BufferWidth - prompt.Length) / 2;
            Console.SetCursorPosition(promptX, yStart + 4);
            Console.Write(prompt);

            // Xử lý nhập lựa chọn
            int choice;
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Vui lòng nhập một số nguyên hợp lệ.");
                Console.WriteLine("Ấn phím bất kỳ để tiếp tục...");
                Console.ReadKey();
                return;
            }

            switch (choice)
            {
                case 1:
                    NhapThongTin();
                    break;

                case 2:
                    HuongDanChoi();
                    break;

                case 3:
                    Console.WriteLine("Cài đặt nhạc chưa được triển khai.");
                    Console.WriteLine("Ấn phím bất kỳ để quay lại menu chính...");
                    Console.ReadKey();
                    break;

                case 4:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Phím bấm không hợp lệ");
                    Console.WriteLine("Ấn phím bất kỳ để quay lại menu chính...");
                    Console.ReadKey();
                    break;
            }
        }

        static void NhapThongTin()
        {
            Console.Clear();
            Console.Write("Nhập tên người chơi: ");
            nguoichoi = Console.ReadLine();

            if (!playerScores.ContainsKey(nguoichoi))
            {
                playerScores[nguoichoi] = new List<int>();
            }

            Console.WriteLine($"Chào mừng {nguoichoi} đến với game!");
            Console.WriteLine("Nhấn phím bất kỳ để bắt đầu game hoặc ESC để quay lại menu chính.");

            while (true)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Escape)
                {
                    return;
                }
                else
                {
                    StartGame();
                    break;
                }
            }
        }

        static void LoaiBo50_50(string[] dapAn, string dapAnDung)
        {
            Random rand = new Random();
            List<int> dapAnSai = new List<int>();

            // Lọc các đáp án sai
            for (int i = 0; i < dapAn.Length; i++)
            {
                if (dapAn[i] != dapAnDung)
                {
                    dapAnSai.Add(i);
                }
            }

            // Chọn ngẫu nhiên 1 đáp án sai để loại bỏ, chỉ còn 2 đáp án
            int indexSai = rand.Next(dapAnSai.Count);
            int indexToRemove = dapAnSai[indexSai];
            dapAn[indexToRemove] = ""; // Loại bỏ đáp án sai

        }

        //private string traloi;
        // Biến toàn cục
        static int diem = 0; // Điểm số
        static int diemCaoNhat = 0; // Điểm cao nhất

        static void StartGame()
        {
            Console.Clear();
            Console.WriteLine($"Bắt đầu game cho người chơi: {nguoichoi}");
            Console.WriteLine("Ấn phím bất kỳ để quay lại menu chính...");
            Console.ReadKey();
            // Danh sách câu hỏi và câu trả lời
            List<CauHoi> danhSachCauHoi = new List<CauHoi>
        {
            new CauHoi("Những rác thải nào thuộc nhóm “Rác thải còn lại”?", new string[] { "Túi nilon, hộp xốp, dụng cụ ăn uống gỗ", "Hộp sữa giấy, bìa carton", "Hộp nhựa, ống hút nhựa", "Hộp thực phẩm, đinh, ốc" }, "A"),
            new CauHoi("Giấy báo, giấy vở, bìa carton thuộc loại rác nào?", new string[] { "Rác thải còn lại", "Hộp sữa", "Giấy","Kim loại" }, "C"),
            new CauHoi("“Mô hình 3” của UEH Go Green Station gồm:", new string[] { "Chất lỏng, thực phẩm thừa, rác thải còn lại", "Thực phẩm thừa, rác tái chế, rác thải còn lại", "Chất lỏng, giấy, hộp sữa", "Thực phẩm thừa, rác tái chế, chất lỏng" }, "B"),
            new CauHoi("Trung bình một người Việt Nam thải ra bao nhiêu tấn CO2 mỗi năm?", new string[] { "2 tấn", "3 tấn", "2,5 tấn", "2,3 tấn" }, "D"),
            new CauHoi("Trước khi xả thải, UEHer, cá nhân ra vào UEH, cần phải làm gì?", new string[] { "Bóc tách rác", "Thực hiện cùng lúc phương án A và C", "Phân loại rác", "Bỏ tất cả vào 1 túi" }, "B"),
            new CauHoi("UEHer hay khách vào UEH cần phải tuân thủ nguyên tắc phân loại rác theo mô hình:", new string[] { "Mô hình 4 và 5", "Mô hình 5 và 6", "Mô hình 3 và 7", "Mô hình 5 và 7" }, "C"),
            new CauHoi("Hộp thực phẩm làm bằng kim loại sẽ thuộc nhóm nào trong Mô hình 7?", new string[] { "Kim loại", "Chất lỏng", "Rác thải còn lại", "Rác tái chế" }, "A"),
            new CauHoi(" Loại rác nào dưới đây không thuộc nhóm “Rác tái chế”?", new string[] { "Giấy báo", "Chai nhựa", "Khẩu trang y tế", "Hộp sữa giấy" }, "C"),
            new CauHoi("Một chai lọ bị vỡ nên được xử lý như thế nào?", new string[] { "Phân loại vào nhóm Thực phẩm thừa", "Bọc kỹ bằng giấy và bỏ vào nhóm Rác thải còn lại", "Bỏ trực tiếp vào nhóm Rác thải còn lại ", "Đập nhỏ thành mảnh vụn trước khi bỏ vào thùng tái chế" }, "B"),
            new CauHoi("Những rác thải nào sau đây cần được phân vào nhóm Rác tái chế: ", new string[] { "Chai, lọ nhựa, rác sân vườn", "Giấy báo, ly giấy, đinh, ốc", "Dụng cụ ăn uống gỗ, ống hút nhựa", "Khăn giấy, khẩu trang" }, "B"),
            new CauHoi("Khi bạn uống không hết ly matcha latte, phần thừa còn lại trong ly cần được phân loại vào nhóm: ", new string[] { "Rác tái chế", "Rác thải còn lại", "Giấy", "Chất lỏng" }, "D"),
            new CauHoi("Loại giấy nào dưới đây được phân loại vào nhóm \"Giấy\" trong mô hình 7? ", new string[] { "Khăn giấy đã qua sử dụng", "Giấy báo, sách cũ", "Võ hộp sữa giấy", "Giấy vệ sinh đã qua sử dụng" }, "B"),
            new CauHoi("Chất nào sau đây là chất thải khó phân hủy? ", new string[] { "Giấy", "Vật chất nhôm", "Giấy nhôm", "Bông" }, "C"),
            new CauHoi("Chất thải động vật có thể chuyển đổi thành… ", new string[] { "Khí tự nhiên", "Khí dầu lỏng (LPG)", "Khí sinh học", "Không có cái nào ở trên" }, "C"),
            new CauHoi("Chất thải rắn bao gồm tất cả các loại sau đây, ngoại trừ: ", new string[] { "Báo và chai nước ngọt", "Thức ăn thừa và mảnh sân", "Ozone và carbon dioxide", "Thư rác và hộp sữa" }, "C"),
            new CauHoi("Loại chất thải nào phân hủy hoàn toàn khi chôn vào đất? ", new string[] { "Chất thải thực vật", "Chất thải nhựa", "Chất thải kim loại", "Chất thải động vật" }, "A"),
            new CauHoi("Rác thải nào sau đây là rác hữu cơ? ", new string[] { "Xương cá", "Túi nilon", "Pin đã qua sử dụng", "Hộp sữa giấy" }, "A"),
            new CauHoi("Rác thải nguy hại bao gồm loại nào sau đây? ", new string[] { "Hộp sữa đã qua sử dụng", "Pin, ắc quy cũ", " Lốp xe cũ", "Giấy carton" }, "B"),
            new CauHoi("Kim loại phế liệu thuộc loại rác nào? ", new string[] { "Rác thải nguy hại", "Rác tái chế", "Rác hữu cơ", "Rác sinh hoạt không tái chế" }, "B"),
            new CauHoi("Bạn đang uống cà phê mang đi và thấy một thùng rác phân loại. Ly cà phê của bạn thuộc loại nào? ", new string[] { "Rác hữu cơ", "Rác tái chế (sau khi rửa sạch)", "Rác thải nguy hại", "Rác thải thông thường" }, "B"),
            new CauHoi("Một chiếc áo cũ nhưng vẫn sử dụng được nên làm gì? ", new string[] { "Vứt vào thùng rác tái chế", "Tặng hoặc tái sử dụng", "Vứt chung với rác sinh hoạt", "Vứt chung với rác sinh hoạt","Bỏ vào thùng rác hữu cơ" }, "B"),
            new CauHoi("Bạn nên xử lý dầu ăn thừa như thế nào? ", new string[] { "Đổ vào bồn rửa chén", "Đổ trực tiếp ra môi trường", "Lưu trữ trong chai và giao cho đơn vị xử lý dầu thải", "Bỏ vào thùng rác tái chế" }, "C"),
            new CauHoi("Pin cũ nếu không được xử lý đúng cách sẽ gây nguy hại gì?", new string[] { "Gây cháy nổ", "Ô nhiễm đất và nước", "Phát tán kim loại nặng vào môi trường", "Tất cả các ý trên" }, "D"),
            new CauHoi("Bình xịt (như bình sơn, thuốc diệt côn trùng) thuộc loại rác nào? ", new string[] { "Rác tái chế", "Rác thải nguy hại", "Rác hữu cơ", "Rác sinh hoạt thông thường" }, "B"),
            new CauHoi("Giấy thuộc phân loại rác nào trong “Mô hình 3” của UEH Go Green Station? ", new string[] { "Giấy", "Rác tái chế", "Rác thải còn lại", "Nhựa tái chế" }, "B"),
            new CauHoi("Tốn bao nhiêu thời gian để phân hủy 1 chai nước làm từ nhựa PET ngoài tự nhiên ", new string[] { "100 - 500 năm để phân hủy hoàn toàn", "450 - 1000 năm để phân hủy hoàn toàn", "500 năm", "100 năm" }, "B"),
            new CauHoi("Quy trình nào sau đây là quy trình tái chế nhựa? ", new string[] { "Nghiền nhỏ, rửa sạch, nấu chảy, ép khuôn", "Đốt cháy, lọc khí, làm mát", "Phơi nắng, sấy khô, nghiền nát", "Rửa sạch, cắt nhỏ, chôn lấp, ủ phân" }, "A"),
            new CauHoi("Những vật dụng nào sau đây có thể dùng thủy tinh tái chế để chế tạo? ", new string[] { "Chip máy tính ", "Giấy", "Bê tông", "Sơn" }, "C"),
            new CauHoi("Nên chọn loại chai nhựa nào dưới đây để có thể sử dụng lại nhiều lần và giảm phát thải? ", new string[] { "Chai nhựa nào cũng như nhau", "Chai nhựa PET", "Chọn loại chai nhựa rẻ nhất", "Chai nhựa HDPE" }, "D"),
            new CauHoi(" Mô hình nào 3R được áp dụng cho dự án UEH Green Campus để phân loại và xử lý rác gồm các bước nào sau đây: ", new string[] { "Rethink, refuse, reduce", "Reduce, reuse, recycle", "Rethink, reduce, responsibility", "Refuse, reduce, reuse" }, "B"),

        };

            Random rand = new Random();
            bool daSuDung5050 = false; // Đánh dấu quyền trợ giúp 50/50
            int soVong = 3; // 3 vòng chơi
            int soCauHoiMoiVong = 5; // 5 câu hỏi mỗi vòng
            int tongDiem = 0;
            // Quá trình chơi
            for (int vong = 1; vong <= soVong; vong++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n--- Vòng {vong} ---");
                List<CauHoi> cauHoiCuaVong = LayCauHoiNgauNhien(danhSachCauHoi, soCauHoiMoiVong, rand);

                int diem = 0;
                int soThuTu = 1;
                foreach (var cauHoi in cauHoiCuaVong)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"  Câu hỏi {soThuTu}: {cauHoi.NoiDung}                                                                   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"    A.  {cauHoi.DapAn[0].PadRight(50)}                                                  ");
                    Console.WriteLine($"    B.  {cauHoi.DapAn[1].PadRight(50)}                                                  ");
                    Console.WriteLine($"    C.  {cauHoi.DapAn[2].PadRight(50)}                                                  ");
                    Console.WriteLine($"    D.  {cauHoi.DapAn[3].PadRight(50)}                                                  ");
                    Console.ResetColor();
                    Console.WriteLine($"╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");

                    // Cho người chơi chọn tính năng 50/50
                    /*Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Chọn tính năng: ");
                    Console.WriteLine("1. Không sử dụng 50/50");
                    Console.WriteLine("2. Sử dụng 50/50 (Loại bỏ 2 đáp án sai)");
                    Console.Write("Nhập lựa chọn của bạn: ");
                    string luaChon = Console.ReadLine();

                    if (luaChon == "2")
                    {
                        // Sử dụng tính năng 50/50
                        // Tạo một bản sao của mảng DapAn và truyền vào
                        string[] dapAnCuaCauHoi = (string[])cauHoi.DapAn.Clone();
                        LoaiBo50_50(dapAnCuaCauHoi, cauHoi.DapAnDung);

                        // Cập nhật lại mảng DapAn trong CauHoi
                        cauHoi.DapAn = dapAnCuaCauHoi;

                        // Hiển thị lại 2 đáp án (1 đúng và 1 sai ngẫu nhiên)
                        Console.WriteLine("Đáp án sau khi sử dụng tính năng 50/50:");
                        int count = 0;
                        foreach (var dapAn in cauHoi.DapAn)
                        {
                            if (!string.IsNullOrEmpty(dapAn)) // Chỉ hiển thị đáp án không trống
                            {
                                char letter = (char)('A' + count);
                                Console.WriteLine($"    {letter}.  {dapAn.PadRight(50)}");
                                count++;
                            }
                        }
                    }*/

                    string chon5050 = " ";
                    while (true)
                    {
                        // Hỏi người chơi xem có muốn sử dụng 50/50 không
                        try
                        {
                            Console.WriteLine("\nBạn có muốn sử dụng quyền trợ giúp 50/50 không? (Y/N)");
                            chon5050 = Console.ReadLine()?.ToUpper();
                            if (chon5050 == "Y" || chon5050 == "N")
                                break;
                            else
                                throw new Exception("Mời bạn nhập đúng Y hoặc N");
                        }
                        catch (Exception loi)
                        {
                            Console.WriteLine(loi.Message);
                        }
                    }
                    if (chon5050 == "Y")
                    {
                        daSuDung5050 = true;
                        // Sử dụng tính năng 50/50
                        // Tạo một bản sao của mảng DapAn và truyền vào
                        string[] dapAnCuaCauHoi = (string[])cauHoi.DapAn.Clone();
                        LoaiBo50_50(dapAnCuaCauHoi, cauHoi.DapAnDung);

                        // Cập nhật lại mảng DapAn trong CauHoi
                        cauHoi.DapAn = dapAnCuaCauHoi;

                        // Hiển thị lại 2 đáp án (1 đúng và 1 sai ngẫu nhiên)
                        /*Console.WriteLine("Đáp án sau khi sử dụng tính năng 50/50:");
                        int count = 0;
                        foreach (var dapAn in cauHoi.DapAn)
                        {
                            if (!string.IsNullOrEmpty(dapAn)) // Chỉ hiển thị đáp án không trống
                            {
                                char letter = (char)('A' + count);
                                Console.WriteLine($"    {letter}.  {dapAn.PadRight(50)}");
                                count++;
                            }
                        }*/


                        // Hiển thị lại câu hỏi với 2 đáp án còn lại
                        Console.WriteLine("\nSau khi sử dụng quyền trợ giúp 50/50:");
                        DisplayOptions(cauHoi.DapAn);
                    }
                    else if (chon5050 == "Y")
                    {
                        Console.WriteLine("Bạn đã sử dụng quyền trợ giúp 50/50 trước đó.");
                    }

                    Console.Write("Chọn đáp án (A/B/C/D): ");
                    string dapAnCuaNguoiChoi = Console.ReadLine().ToUpper();

                    // Hàm trợ giúp để hiển thị các lựa chọn
                    static void DisplayOptions(string[] options)
                    {
                        char optionLetter = 'A'; // Đánh dấu các lựa chọn từ A, B, C, D
                        /*for (int i = 0; i < options.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(options[i]))
                            {
                                Console.WriteLine($"{optionLetter}. {options[i]}");
                            }
                            optionLetter++;
                        }*/
                        foreach (var option in options)
                        {
                            if (!string.IsNullOrEmpty(option))
                            {

                                Console.WriteLine($"{optionLetter}. {option}");
                                optionLetter++;
                            }
                        }
                    }

                    if (dapAnCuaNguoiChoi == cauHoi.DapAnDung)
                    {
                        Console.WriteLine("Đúng!");
                        diem++;
                    }
                    else
                    {
                        Console.WriteLine($"Sai! Đáp án đúng là: {cauHoi.DapAnDung}");
                    }

                    soThuTu++;
                    Console.WriteLine();
                    Console.WriteLine();
                }

                Console.WriteLine($"Điểm của bạn ở Vòng {vong}: {diem}/{soCauHoiMoiVong}");
                // Cộng dồn điểm vào tổng điểm
                tongDiem += diem;
            }
            Console.ReadKey();
            KetThucGame(tongDiem);
            //Console.WriteLine("\nTrò chơi kết thúc! Cảm ơn bạn đã tham gia!");
        }
        // Hàm chọn câu hỏi ngẫu nhiên
        static List<CauHoi> LayCauHoiNgauNhien(List<CauHoi> danhSachCauHoi, int soCauHoi, Random rand)
        {
            List<CauHoi> cauHoiDaChon = new List<CauHoi>();
            HashSet<int> chiSoCauHoiDaChon = new HashSet<int>();

            while (cauHoiDaChon.Count < soCauHoi)
            {
                int chiSo = rand.Next(danhSachCauHoi.Count);

                if (!chiSoCauHoiDaChon.Contains(chiSo))
                {
                    chiSoCauHoiDaChon.Add(chiSo);
                    cauHoiDaChon.Add(danhSachCauHoi[chiSo]);
                }
            }
            return cauHoiDaChon;
        }


        static void HuongDanChoi()
        {
            Console.Clear();
            Console.WriteLine("\t\tHƯỚNG DẪN");
            Console.WriteLine("Trò chơi mô phỏng với các câu hỏi và lựa chọn...");
            Console.WriteLine("\nNhấn ESC để thoát hướng dẫn");

            while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;
        }


        // Cấu trúc câu hỏi
        class CauHoi
        {
            public string NoiDung { get; set; }
            public string[] DapAn { get; set; }
            public string DapAnDung { get; set; }

            public CauHoi(string noiDung, string[] dapAn, string dapAnDung)
            {
                NoiDung = noiDung;
                DapAn = dapAn;
                DapAnDung = dapAnDung;
            }
        }

        static void KetThucGame(int tongDiem)
        {
            Console.Clear();
            Console.WriteLine("\t\t-------------------------------");
            Console.WriteLine("\t\t------ TRÒ CHƠI KẾT THÚC ------");
            Console.WriteLine("\t\t-------------------------------");
            Console.WriteLine($"\t\tĐiểm của bạn là: {tongDiem}");
            if (tongDiem > 1)
            {
                diemCaoNhat = tongDiem;
                Console.WriteLine("\t\tXin chúc mừng bạn đã được 2 điểm rèn luyện\n");
            }
            Console.WriteLine("\t\tNhấn phím Enter để quay lại bảng chọn hoặc nhấn r để chơi lại");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\t\tĐIỂM CAO NHẤT: {diemCaoNhat}");
            Console.ResetColor();

            bool nenThoat = false;

            while (!nenThoat)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        nenThoat = true;
                        break;
                    default:
                        if (keyInfo.KeyChar == 'r' || keyInfo.KeyChar == 'R') // Chơi lại
                        {
                            StartGame();
                            nenThoat = true;
                        }
                        break;
                }
            }
        }
    }
}
