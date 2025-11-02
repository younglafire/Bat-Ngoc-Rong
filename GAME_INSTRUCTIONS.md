# Chi tiết về Trò chơi Bắt Ngọc Rồng
# Detailed Game Instructions

## Các thành phần trò chơi (Game Components)

### 1. Giao diện chính (Main Interface)
- **Tiêu đề**: "Bắt Ngọc Rồng" hiển thị trên thanh tiêu đề
- **Màu nền**: Xanh da trời (SkyBlue) - giống bầu trời trong anime Dragon Ball
- **Kích thước**: 800x600 pixels

### 2. Thông tin hiển thị (Display Information)
Trên đầu màn hình, bạn sẽ thấy:
- **Điểm số** (góc trái): Hiển thị số điểm hiện tại
- **Cấp độ** (giữa): Hiển thị cấp độ hiện tại
- **Mạng sống** (góc phải): Hiển thị số tim còn lại (❤ x 3)

### 3. Viên Ngọc Rồng (Dragon Balls)
Mỗi viên Ngọc Rồng có:
- **Hình dạng**: Hình tròn màu cam (orange)
- **Viền**: Viền đen dày 2 pixels
- **Sao**: 1-7 ngôi sao đỏ (★) ở giữa viên ngọc
- **Kích thước**: 40 pixels

### 4. Cơ chế chơi (Game Mechanics)

#### Bắt Ngọc Rồng (Catching)
- Click chuột vào viên Ngọc Rồng để bắt
- Khi bắt thành công, viên ngọc biến mất và bạn nhận điểm

#### Hệ thống điểm (Scoring System)
```
Cấp độ 1: +1 điểm/viên
Cấp độ 2: +2 điểm/viên
Cấp độ 3: +3 điểm/viên
Cấp độ 4: +4 điểm/viên
...và tiếp tục
```

#### Nâng cấp độ (Level Up)
- Bắt đủ 7 viên Ngọc Rồng khác nhau (1★, 2★, 3★, 4★, 5★, 6★, 7★)
- Tốc độ rơi tăng lên
- Điểm thưởng tăng lên
- Bộ đếm sao reset về 0

#### Mất mạng (Losing Lives)
- Nếu để viên Ngọc Rồng rơi xuống đất → Mất 1 tim
- Ban đầu có 3 tim
- Hết tim → Game Over

#### Game Over
Khi hết mạng, xuất hiện hộp thoại:
```
"Bạn đã thua!
Điểm số: [số điểm của bạn]

Bạn có muốn chơi lại không?"
```
Hai nút:
- **Yes**: Chơi lại từ đầu
- **No**: Quay về màn hình chính (hiện nút BẮT ĐẦU)

## Kỹ thuật lập trình (Programming Techniques)

### Các biến chính (Main Variables)
- `dragonBalls`: Danh sách các viên Ngọc Rồng đang rơi
- `score`: Điểm số hiện tại
- `lives`: Số mạng còn lại
- `speed`: Tốc độ rơi (pixels/tick)
- `difficultyLevel`: Cấp độ hiện tại
- `caughtStars`: Tập hợp các loại sao đã bắt được

### Timer
- Interval: 20ms (50 FPS)
- Cập nhật vị trí viên Ngọc Rồng
- Tạo viên Ngọc Rồng mới ngẫu nhiên
- Kiểm tra va chạm với đất

### Rendering
- Sử dụng GDI+ (Graphics)
- Anti-aliasing cho đồ họa mượt mà
- Double buffering để tránh nhấp nháy

## Mẹo chơi (Tips)
1. Tập trung vào các viên Ngọc Rồng gần đất trước
2. Nhớ số sao bạn đã bắt để biết khi nào lên cấp
3. Ở cấp độ cao, phản ứng nhanh là chìa khóa
4. Đừng bỏ lỡ bất kỳ viên nào - chỉ có 3 cơ hội!

## Phong cách 8-bit (8-bit Style)
Game sử dụng phong cách đồ họa đơn giản:
- Hình học cơ bản (tròn)
- Màu sắc rõ ràng, tương phản cao
- Font chữ đậm, dễ đọc
- Không có hiệu ứng phức tạp
- Tương tự các game cổ điển như Tetris, Pac-Man

## Yêu cầu hệ thống (System Requirements)
- **OS**: Windows 7/8/10/11
- **.NET Framework**: 4.7.2 trở lên
- **RAM**: 256 MB trở lên
- **Màn hình**: 800x600 trở lên
- **Input**: Chuột (Mouse)

## Phát triển tương lai (Future Enhancements)
Có thể thêm:
- Âm thanh (nhạc nền, hiệu ứng)
- Bảng xếp hạng điểm cao
- Power-ups (vật phẩm đặc biệt)
- Nhiều chế độ chơi
- Hiệu ứng particle khi bắt ngọc
- Animation cho ngọc rồng
