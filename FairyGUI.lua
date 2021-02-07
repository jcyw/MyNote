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
        --  onDragStart：拖动结束

        --  onTouchBegin
        --  onTouchMove
        --  onTouchEnd
        --  ScrollPane.scrollStep: 当调用ScrollPane.scrollUp/Down/Left/Right时，或者点击滚动条的上下箭头时，滑动的距离。 鼠标滚轮触发一次滚动的距离设定为defaultScrollStep*2
        --  ScrollPane.touchEffect: 是否允许拖拽内容区域进行滚动。
    --##Method
        --  self.list:ResizeToFit(self.list.numItems) :列表会跟随子项目的多少调整大小


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


    --[如果想text可以滑动，就把text做成组件]

--------------------------------GoWrapper-------------------------------------
    --GoWrapper是一个将普通游戏对象包装到UI显示列表中的类
    ------Constructors
        --GoWrapper(GameObject) 

---------------------------------GGraph----------------------------------------
    -------Methond
        --SetNativeObject(DisplayObject obj)
            --设置内容为一个原生对象，这个图形对象相当于一个占位的用途
            --Patameters : obj --<type> = FairyGUI.DisplayObject(原生对象)
            --eg:   tempwrap = GoWrapper(obj)
            --      ggraph:SetNativeObject(tempwrap)
