using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrungTamGiaSu_31_Minh
{
    public class Student_31_Minh
    {
        public string StudentId_31_Minh { get; set; }
        public string FullName_31_Minh { get; set; }
        public string HomeTown_31_Minh { get; set; }
        public double MathScore_31_Minh { get; set; }
        public double LiteratureScore_31_Minh { get; set; }
        public double EnglishScore_31_Minh { get; set; }
        
        //Phương thức khởi tạo
        public Student_31_Minh(string studentId_31_Minh, string fullName_31_Minh, string homeTown_31_Minh, double mathScore_31_Minh, double literatureScore_31_Minh, double englishScore_31_Minh)
        {
            StudentId_31_Minh = studentId_31_Minh;
            FullName_31_Minh = fullName_31_Minh;
            HomeTown_31_Minh = homeTown_31_Minh;
            MathScore_31_Minh = mathScore_31_Minh;
            LiteratureScore_31_Minh = literatureScore_31_Minh;
            EnglishScore_31_Minh = englishScore_31_Minh;
        }

        //Kiểm tra học viên có được nhận học bổng hay không
        public bool isScholarship_31_Minh()
        {
            double avg_31_Minh = (MathScore_31_Minh + LiteratureScore_31_Minh + EnglishScore_31_Minh) / 3.0;
            return avg_31_Minh >= 8.0 && MathScore_31_Minh >= 5.0 && LiteratureScore_31_Minh >= 5.0 && EnglishScore_31_Minh >= 5.0;
        }

        //Kiểm tra thông tin hợp lệ của học viên
        public bool isNotEmptyInfo_31_Minh()
        {
            return StudentId_31_Minh != String.Empty && FullName_31_Minh != String.Empty && HomeTown_31_Minh != String.Empty;
        }
        //Kiểm tra tính hợp lệ của điểm số
        public bool isValidScore_31_Minh()
        {
            return MathScore_31_Minh >= 0 && MathScore_31_Minh <= 10 && LiteratureScore_31_Minh >= 0 && LiteratureScore_31_Minh <= 10 && EnglishScore_31_Minh >= 0 && EnglishScore_31_Minh <= 10;
        }
    }
}
