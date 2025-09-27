using System.Security.Cryptography.X509Certificates;

namespace Kiemtra
{
    internal class Baitap
    {
        static void Main()
        {
            do
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine("Chọn bài tập (1-5) hoặc 0 để thoát:");
                Console.WriteLine("1. Xếp loại học lực sinh viên");
                Console.WriteLine("2. Tính điểm trung bình, điểm cao và điểm thấp nhất");
                Console.WriteLine("3. Quản lý danh sách sinh viên");
                Console.WriteLine("4. Quản lý danh sách sinh viên với mã số");
                Console.WriteLine("5. Quản lý danh sách sinh viên với lớp đối tượng");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Đầu vào không hợp lệ. Vui lòng nhập một số.");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        Bai1();
                        break;
                    case 2:
                        bai2();
                        break;
                    case 3:
                        bai3();
                        break;
                    case 4:
                        bai4();
                        break;
                    case 5:
                        bai5va6();
                        break;
                    case 0:
                        Console.WriteLine("Kết thúc chương trình.");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }

            }
            while (true);

            static void Bai1()
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine("Nhập điểm số (0-10): ");
                if (!double.TryParse(Console.ReadLine(), out double diemso))
                {
                    Console.WriteLine("Đầu vào không hợp lệ. Vui lòng nhập một số.");
                    return;
                }
                if (diemso < 0 || diemso > 10)
                {
                    Console.WriteLine("Điểm số không hợp lệ.");
                }
                if (diemso < 5)
                {
                    Console.WriteLine("Trượt");
                }
                else if (diemso < 7)
                {
                    Console.WriteLine("Trung bình");
                }
                else if (diemso < 8.5)
                {
                    Console.WriteLine("Khá");
                }
                else
                {
                    Console.WriteLine("Giỏi");
                }
                Console.WriteLine("Bạn có muốn tiếp tục không? (y/n)");
                if (!char.TryParse(Console.ReadLine(), out char tieptuc))
                {
                    Console.WriteLine("Đầu vào không hợp lệ. Vui lòng nhập 'y' hoặc 'n'.");
                    return;
                }
                if (tieptuc == 'y' || tieptuc == 'Y')
                {
                    Bai1();
                }
                else
                {
                    Console.WriteLine("Kết thúc chương trình.");
                }
            }


            static void bai2()
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine("Nhập số lượng sinh viên : ");
                if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
                {
                    Console.WriteLine("Đầu vào không hợp lệ. Vui lòng nhập một số nguyên dương.");
                    return;
                }
                double[] diemso = new double[n];
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Nhập điểm số sinh viên : ");
                    diemso[i] = double.Parse(Console.ReadLine());
                }

                double diemtong = 0;
                for (int i = 0; i < n; i++)
                {
                    diemtong += diemso[i];
                }
                double diemtrungbinh = diemtong / n;
                Console.WriteLine("Điểm trung bình là: {0}", diemtrungbinh);

                double max = diemso[0];
                for (int i = 0; i < n; i++)
                {

                    if (diemso[i] > max)
                    {
                        max = diemso[i];
                    }
                }
                Console.WriteLine("Điểm số cao nhất là: {0}", max);

                double min = diemso[0];
                for (int i = 0; i < n; i++)
                {

                    if (diemso[i] < min)
                    {
                        min = diemso[i];
                    }

                }
                Console.WriteLine("Điểm số thấp nhất là: {0}", min);
            }
            static void bai3()
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                List<string> students = new List<string>();
                while (true)
                {
                    Console.WriteLine("Nhập tên sinh viên (hoặc gõ 'end' để thoát): ");
                    string name = Console.ReadLine();
                    if (name.ToLower() == "end")
                    {
                        break;
                    }
                    students.Add(name);
                }
                Console.WriteLine("Danh sách sinh viên đã nhập:");
                foreach (string a in students)
                {
                    Console.WriteLine(a);
                }
                string longestName = students[0];
                foreach (string a in students)
                {
                    if (a.Length > longestName.Length)
                    {
                        longestName = a;
                    }
                }
                Console.WriteLine("Tên sinh viên dài nhất là: {0}", longestName);
            }
            static void bai4()
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Dictionary<string, string> students = new Dictionary<string, string>();
                while (true)
                {
                    Console.WriteLine("Nhập tên sinh viên (hoặc gõ 'end' để thoát): ");
                    string name = Console.ReadLine();
                    if (name.ToLower() == "end")
                    {
                        break;
                    }
                    Console.WriteLine("Nhập mã số sinh viên: ");
                    string id = Console.ReadLine();
                    students[name] = id;
                }
                Console.WriteLine("Danh sách sinh viên đã nhập:");
                foreach (var student in students)
                {
                    Console.WriteLine("Tên: {0}, Mã số: {1}", student.Key, student.Value);
                }
                Console.WriteLine("Nhập tên sinh viên để tìm kiếm mã số: ");
                string searchName = Console.ReadLine();
                if (students.ContainsKey(searchName))
                {
                    Console.WriteLine("Mã số của {0} là: {1}", searchName, students[searchName]);
                }
                else
                {
                    Console.WriteLine("Không tìm thấy sinh viên với tên {0}", searchName);
                }
            }
            static void bai5va6()
            {
                List<Student> students = new List<Student>();
                Console.WriteLine("Nhập số lượng sinh viên (>=3): ");
                int n = int.Parse(Console.ReadLine());
                if (n < 3)
                {
                    Console.WriteLine("Số lượng sinh viên phải lớn hơn hoặc bằng 3.");
                    return;
                }
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"Nhập thông tin sinh viên thứ {i + 1}:");
                    Console.Write("Mã số: ");
                    string id = Console.ReadLine();
                    Console.Write("Tên: ");
                    string name = Console.ReadLine();
                    Console.Write("Điểm: ");
                    double score = double.Parse(Console.ReadLine());
                    students.Add(new Student(id, name, score));
                }
                Console.WriteLine("Danh sách sinh viên:");
                foreach (var student in students)
                {
                    student.DisplayInfo();
                }
                Student topStudent = students[0];
                for (int i = 1; i < students.Count; i++)
                {
                    if (students[i].Score > topStudent.Score)
                    {
                        topStudent = students[i];
                    }
                }
                Console.WriteLine("Sinh viên có điểm cao nhất:");
                topStudent.DisplayInfo();

                Console.WriteLine("Sinh viên có điểm >=8 : ");
                foreach (var student in students)
                {
                    if (student.Score >= 8)
                    {
                        student.DisplayInfo();
                    }
                }

                Console.WriteLine("Nhập tên sinh viên để tìm kiếm: ");
                string searchName = Console.ReadLine();
                bool found = false;
                foreach (var student in students)
                {
                    if (student.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Thông tin sinh viên tìm thấy:");
                        student.DisplayInfo();
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Không tìm thấy sinh viên với tên {0}", searchName);
                }
            }

        }

        public class Student
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public double Score { get; set; }
            public Student(string id, string name, double score)
            {
                ID = id;
                Name = name;
                Score = score;
            }
            public override string ToString()
            {
                return $"Mã số: {ID}, Tên: {Name}, Điểm: {Score} ";
            }
            public void DisplayInfo()
            {
                Console.WriteLine(this.ToString());
            }
        }
    }
}


