# alarm.py
import time
import tkinter as tk


class Application(tk.Frame):
    def __init__(self, master=None):
        super().__init__(master)
        self.master = master
        self.pack(fill=tk.BOTH, expand=True)
        self.create_widgets()

    def create_widgets(self):
        self.info = tk.Label(self,
                              font="Fixedsys 36 bold",
                              text=r" 该喝水了！ ")
        self.info.pack(fill=tk.X, pady=24)
    
        self.quit = tk.Button(self,
                              font="Fixedsys 36 bold",
                              text=r" 知道了，这就去提一壶！ ",
                              bg="red",
                              fg='white',
                              command=self.master.destroy)
        self.quit.pack(fill=tk.X, pady=16)


def SetAlarm(time_str):
    set_hour = int(time_str.split(':')[0])
    set_mint = int(time_str.split(':')[1])
    while True:
        t = time.localtime()
        fmt = "%H %M"
        now = time.strftime(fmt, t)
        now = now.split(' ')
        hour = int(now[0])
        mint = int(now[1])
        
        if hour != 13 and hour >= set_hour and mint == set_mint:
            if set_hour < 19: # if not poped before then pop a window
                print(str(hour)+"点啦！ 请喝水！！！！！")
                set_hour = hour + 1
                root = tk.Tk()
                root.wm_attributes('-topmost',1)
                root["background"] = "blue"
                root.attributes("-fullscreen", True)
                app = Application(master=root)
                app.mainloop()
            else: # window poped before then cancel the alarm this time
                break
        else:
            set_hour = set_hour 
            
if __name__ == '__main__':
    SetAlarm('10:08')