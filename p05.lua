--------------------------------------------------UI 部分-----------------------------------
su <------> _G 全局

--ui创建以及生命周期
BaseUI.lua

--创建ui  
local uiName = su.UIMgr:UIExten("ui://baoming/zujianming",su.FUIGComponent)

--点击事件
self._btn.onClick:Set(function() end)

--设置图片
self.icon.url = su.UIMgr:GetItemURL("pkg_name","pic_name")

--读表相关
tbMgr.lua