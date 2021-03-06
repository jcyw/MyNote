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
--动态加载
su.Util:SetDynamicTex2d(self._banner,"Banner/banner_welfare",config.banner) --<fgui-conponent,pkg_name,banner_name>

--读表相关
tbMgr.lua

--特效相关
EffectUtil.lua
--eg:
function A:AddEffect()
    if not self.effect then
        self.effect = EffEctUtil:CreatGFuiEffectNode(effectPath)    --eg : <effectPath = "prefabs/effect05/effect_get_props">
    end
    EffEctUtil:SetFGuiEffectNodeDetail(self.effect,self._effect,
    0.45 * self._effect.height，0.45 * self._effect.height，0.45 * self._effect.width.45 * self._effect.height)
    ---EffEctUtil:SetFGuiEffectNodeDetail(effect,parent,scanX,scanY,scanZ,posX,posY)
    EffEctUtil:PlayFGuiEffect(self.effect)
end

--加载spine
DynamicRes.lua
--eg:
funciton RecruitResult:CheckDeleteSpine()
    if mObj then
        su.GameObject.Destroy(mObj)
        mObj = nil
    end
end
local mWrap
funciton RecruitResult:LoadSpine(id,targetImg,action)
    self:CheckDeleteSpine()
    local resName = action.."_Anim"
    local bundleName = string.format("Spine/%s",action)
    su.DynamicRes.GetPrefab(bundleName,resName,function(spineObj)
        local obj = su.Instantiate(spineObj)
        mObj = obj
        local conf = su.tbMgr.GetItem("HeroType",id)
        local position = conf.position
        local size = conf.size
        obj.transform.localPosition = CVector3(position[1],position[2],1000)
        obj.transform.localScale = CVector3(size[1],size[2],1)
        obj.transform.localEulerAngles = CVector3.zero
        if mObj == nil then
            mWrap = su.GoWrapper(mObj)
            targetImg:SetNativeObject(mWrap)
        else
            mWrap.wrapTarget = mObj
        end
    end)
end