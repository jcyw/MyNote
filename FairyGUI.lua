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