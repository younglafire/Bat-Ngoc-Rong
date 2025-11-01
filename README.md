# Bắt Ngọc Rồng (Dragon Ball Catching Game)

## Mô tả trò chơi (Game Description)

Đây là một trò chơi Windows Forms đơn giản theo phong cách 8-bit cổ điển, trong đó người chơi phải bắt các viên Ngọc Rồng đang rơi xuống.

This is a simple Windows Forms game in 8-bit retro style where players catch falling Dragon Balls.

## Cách chơi (How to Play)

1. **Bắt đầu**: Nhấn nút "BẮT ĐẦU" để bắt đầu trò chơi
   - **Start**: Click the "BẮT ĐẦU" button to start the game

2. **Bắt Ngọc Rồng**: Nhấp chuột vào các viên Ngọc Rồng (1-7 sao) đang rơi xuống
   - **Catch Dragon Balls**: Click on the falling Dragon Balls (1-7 stars)

3. **Điểm số**: 
   - Cấp độ 1: +1 điểm/viên
   - Cấp độ 2: +2 điểm/viên
   - Cấp độ 3: +3 điểm/viên
   - ...và tiếp tục tăng
   - **Scoring**:
   - Level 1: +1 point per ball
   - Level 2: +2 points per ball
   - Level 3: +3 points per ball
   - ...and continues to increase

4. **Nâng cấp độ**: Sau khi bắt đủ 7 viên Ngọc Rồng khác nhau (1-7 sao), tốc độ rơi sẽ nhanh hơn và điểm thưởng tăng lên
   - **Level Up**: After catching 7 different Dragon Balls (1-7 stars), falling speed increases and points multiply

5. **Mạng sống**: Bạn có 3 tim (3 lần bỏ lỡ). Khi để viên Ngọc Rồng rơi xuống đất, bạn mất 1 tim
   - **Lives**: You have 3 hearts (3 chances). Missing a Dragon Ball costs 1 heart

6. **Kết thúc**: Khi hết mạng, trò chơi kết thúc. Bạn có thể chọn chơi lại hoặc thoát
   - **Game Over**: When out of lives, the game ends. You can choose to play again or quit

## Cách chạy (How to Run)

### Yêu cầu (Requirements)
- Windows Operating System
- .NET Framework 4.7.2 or higher
- Visual Studio 2015 or later (recommended)

### Chạy từ Visual Studio (Run from Visual Studio)
1. Mở file `TEST.sln` trong Visual Studio
2. Nhấn `F5` hoặc click nút "Start" để chạy trò chơi

### Build và chạy (Build and Run)
```batch
# Sử dụng MSBuild
msbuild TEST.sln /p:Configuration=Release

# Chạy file exe
bin\Release\TEST.exe
```

## Tính năng (Features)

✅ Giao diện đơn giản, phong cách 8-bit
- Simple interface, 8-bit style

✅ Viên Ngọc Rồng 1-7 sao với màu cam và sao đỏ
- Dragon Balls with 1-7 stars, orange color with red stars

✅ Hệ thống điểm số và cấp độ
- Scoring and leveling system

✅ 3 mạng sống (tim)
- 3 lives (hearts)

✅ Tốc độ tăng dần theo cấp độ
- Speed increases with levels

✅ Màn hình kết thúc với tùy chọn chơi lại
- Game over screen with replay option

✅ Giao diện tiếng Việt
- Vietnamese interface

## Cấu trúc mã (Code Structure)

- `Form1.cs`: Logic trò chơi chính
  - Main game logic
  
- `Form1.Designer.cs`: Thiết kế giao diện
  - UI design
  
- `DragonBall` class: Đại diện cho viên Ngọc Rồng
  - Represents a Dragon Ball object

## Công nghệ (Technology)

- C# Windows Forms
- .NET Framework 4.7.2
- GDI+ for graphics rendering
