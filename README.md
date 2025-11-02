# Bắt Ngọc Rồng (Dragon Ball Catching Game)

## Mô tả trò chơi (Game Description)

Đây là một trò chơi Windows Forms đơn giản theo phong cách 8-bit cổ điển, trong đó người chơi phải bắt các viên Ngọc Rồng đang rơi xuống.


## Cách chơi

1. **Bắt đầu**: Nhấn nút "BẮT ĐẦU" để bắt đầu trò chơi
   - **Start**: Click the "BẮT ĐẦU" button to start the game

2. **Bắt Ngọc Rồng**: Nhấp chuột vào các viên Ngọc Rồng (1-7 sao) đang rơi xuống

3. **Điểm số**: 
   - Cấp độ 1: +1 điểm/viên
   - Cấp độ 2: +2 điểm/viên
   - Cấp độ 3: +3 điểm/viên
   - ...và tiếp tục tăng


4. **Nâng cấp độ**: Sau khi bắt đủ 7 viên Ngọc Rồng khác nhau (1-7 sao), tốc độ rơi sẽ nhanh hơn và điểm thưởng tăng lên

5. **Mạng sống**: Bạn có 3 tim (3 lần bỏ lỡ). Khi để viên Ngọc Rồng rơi xuống đất, bạn mất 1 tim

6. **Kết thúc**: Khi hết mạng, trò chơi kết thúc. Bạn có thể chọn chơi lại hoặc thoát

## Cách chạy 

### Yêu cầu (Requirements)
- Windows Operating System
- .NET Framework 4.7.2 or higher
- Visual Studio 2015 or later (recommended)

### Chạy từ Visual Studio (Run from Visual Studio)
1. Mở file `TEST.sln` trong Visual Studio
2. Nhấn `F5` hoặc click nút "Start" để chạy trò chơi

### Build và chạy
```batch
# Sử dụng MSBuild
msbuild TEST.sln /p:Configuration=Release

# Chạy file exe
bin\Release\TEST.exe
```

## Tính năng (Features)

✅ Giao diện đơn giản, phong cách 8-bit

✅ Viên Ngọc Rồng 1-7 sao với màu cam và sao đỏ

✅ Hệ thống điểm số và cấp độ

✅ 3 mạng (tim)

✅ Tốc độ tăng dần theo cấp độ

✅ Màn hình kết thúc với tùy chọn chơi lại

✅ Giao diện tiếng Việt

## Cấu trúc mã (Code Structure)

- `Form1.cs`: Logic trò chơi chính
  
- `Form1.Designer.cs`: Thiết kế giao diện
  
- `DragonBall` class: Đại diện cho viên Ngọc Rồng


