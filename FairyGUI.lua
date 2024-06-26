-----------------通用-----------------------------
    --  sortingOrder: 设置显示层级：panel.SetSortingOrder(1, true);
    --                UIPanel在屏幕上的显示顺序是由他的sortingOrder属性决定的。sortingOrder越大，显示在越前面（越靠近屏幕）。
    --                对sortingOrder为100的UIPanel按z进行排序，z值越小，显示在越前面。Stage.inst.SortWorldSpacePanelsByZOrder(100);

-----------------GList-----------------------------

    --##Properties
        --	actualHeight:绝对高度=height * scaleY
        --  actualWidth:绝对宽度=width * scalex
        --  columnCount：列数
        --  columnGap: 列距
        --	Controllers：控制器
        --  draggable：可拖拽(list.draggable = true/false)
        --  grayed:变灰 
        --	numChildren：返回子节点个数
        --	numItems：设置子对象个数，可用于刷新列表
        --  onClick
        --  onClickItem:子对象点击事件
                -- self:AddListener(self.list.onClickItem,function(context)
                --         local item = context.data   --这个item就是点击的item 可操作
                --     )

        --  onDragStart：拖动开始
        --  onDragMove：拖动ing
        --  onDragEnd：拖动结束

        --  onTouchBegin
        --  onTouchMove
        --  onTouchEnd
        --  ScrollPane.scrollStep: 当调用ScrollPane.scrollUp/Down/Left/Right时，或者点击滚动条的上下箭头时，滑动的距离。 鼠标滚轮触发一次滚动的距离设定为defaultScrollStep*2
        --  ScrollPane.touchEffect: 是否允许拖拽内容区域进行滚动。
        --  ScrollPane.onPullUpRelease: 下拉刷新
        --  ScrollPane.posY : 列表滑动列表外到列表顶端的距离
    --##Method
        --  self.list:ResizeToFit(self.list.numItems) :列表会跟随子项目的多少调整大小

    --##Method滚动列表以使具有特定索引的项目可见。
--         public  void  ScrollToView (
-- 	            int  index ,
-- 	            bool  ani ,
-- 	            bool  setFirst 
--          )
--          参数：
--              index
--                  Type： System.Int32
--                  Item index
--              ani
--                  Type: System.Boolean
--                  True 平滑滚动，否则立即滚动。
--              setFirst
--                  Type: System.Boolean
--                  如果为 true，则滚动使目标位于顶部/左侧；如果为 false，则滚动以使目标处于视野中的任何位置。
--lua 调用 self.list:ScrollToView()
--列表item组件高度可变时， 一定不能让适配相互影响， 自适应列表对齐方式不能上下居中

-----------------GObject-----------------------------

    --##Method
        --  GObject.TweenMoveX(float endValue，float duration)
            --param[结束位置，播完动画所需时间]
        --  GObject.TweenMoveY(float endValue，float duration)


-----------------GTextField----------------------------
    
    --##Property
        -- GTextField.autoSize  文本自动大小
            --AutoSizeType Both-1   宽度和高度
            --             Height-2 高度
            --             None-0   无
            --             Shrink-3 自动收缩

        --  GTextInput.promptText   输入文本默认文本（自身支持ubb）
    --[如果想text可以滑动，就把text做成组件]

--------------------------------GoWrapper-------------------------------------
    --GoWrapper是一个将普通游戏对象包装到UI显示列表中的类
    ------Constructors
        --GoWrapper(GameObject) 

    ------Property
        --GoWrapper.wrapTarget
        --设置包装对象。注意如果原来有包装对象，设置新的包装对象后，原来的包装对象只会被删除引用，但不会被销毁。
        --对象包含的所有材质不会被复制，如果材质已经是公用的，这可能影响到其他对象。如果希望自动复制，
        --改为使用SetWrapTarget(target,true)设置

    ------SetWrapTarget(GameObject target,bool cloneMaterial)
        --设置包装对象。注意如果原来有包装对象，设置新的包装对象后，原来的包装对象只会删除引用，但不会 被销毁
        --Parameters
            --cloneMaterial<bool>如果true,则复制材质，否则直接使用shareMaterial


--********************项目例子（英雄spine）**************************
-- funciton RecruitResult:CheckDeleteSpine()
--     if mObj then
--         su.GameObject.Destroy(mObj)
--         mObj = nil
--     end
-- end
-- local mWrap
-- funciton RecruitResult:LoadSpine(id,targetImg,action)
--     self:CheckDeleteSpine()
--     local resName = action.."_Anim"
--     local bundleName = string.format("Spine/%s",action)
--     su.DynamicRes.GetPrefab(bundleName,resName,function(spineObj)
--         local obj = su.Instantiate(spineObj)
--         mObj = obj
--         local conf = su.tbMgr.GetItem("HeroType",id)
--         local position = conf.position
--         local size = conf.size
--         obj.transform.localPosition = CVector3(position[1],position[2],1000)
--         obj.transform.localScale = CVector3(size[1],size[2],1)
--         obj.transform.localEulerAngles = CVector3.zero
--         if mObj == nil then
--             mWrap = su.GoWrapper(mObj)
--             targetImg:SetNativeObject(mWrap)
--         else
--             mWrap.wrapTarget = mObj
--         end
--     end)
-- end
--******************************************************************
---------------------------------GGraph----------------------------------------
    -------Methond
        --SetNativeObject(DisplayObject obj)
            --设置内容为一个原生对象，这个图形对象相当于一个占位的用途
            --Patameters : obj --<type> = FairyGUI.DisplayObject(原生对象)
            --eg:   tempwrap = GoWrapper(obj)
            --      ggraph:SetNativeObject(tempwrap)

--------------------------------------------------------------------------------


-------------------------------------- DC --------------------------------------

-- 定义： cpu每次准备好数据并调用一次gpu方法的过程叫做一次DC [一次dc的数据取决于渲染顺序，层级]
--        [已同一层级为例，如果同一层级存在多个图集的数据，就会打断合批，cpu表现为多次提交数据]
--        [fgui : 如果一个包导出多个图集（图集越大越吃内存），如果两张图不在同一图集依然会打断合批，
--         目前项目理想状态是一个包拆成一张1024的图集，然后为了减少打断合批，我们可以接受同一张小图
--         出现在不同的包里面（消耗少量内存减少dc）]



--------------------------------------------------------------------------------

--------------------------------------GButton------------------------------------

-- self.btn.onTouchBegin:Add(function(context)
--         context:CapTureTouch()  --如果触摸离开组件的话onTouchEnd就监听不到这个时候加上这个就可以捕获
-- end)End

-- self.btn.onTouchEnd:Add(function(context)
-- end)
----------------------------------------------------------------------------------

------------------------------------GProgressBar----------------------------------

-- GProgressBar.TweenValue：动态改变进度值。
----------------------------------------------------------------------------------

-------------------------------------GComponet------------------------------------
--GComponet : GObject
--GObject 成员变量 DisplayObject displayObject
--DisplayObject 成员变量 GameObject gameObject
--设置组件位置 : self.dispalyObject.gameObject.transform.position
----------------------------------------------------------------------------------

-------