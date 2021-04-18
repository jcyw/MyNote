import os
import shutil

# 获取分支
cmd = "git rev-parse --abbrev-ref HEAD"
branch = os.open('git rev-parse --abbrev-ref HEAD').read().strip()

if "develop" in branch:
    branch = "develop"
    print("================ 导出develop配置文件 ================")
elif "master" in branch:
    branch = "master"
    print("================ 导出master配置文件 ================")
else : 
    branch = "develop"
    print("================ 导出develop配置文件 ================")


exc_path = "./Generator/config"

# 更新配置
# git
os.system("cd {excPath} && git pull".format(excPath = exc_path))

# svn win
# os.system("cd {excPath} && svn up".format(excPath = exc_path))

#清理配置
loc_branch_exc_path = "./Generator/config/{loc_branch}/gen/excels".format(loc_branch = branch)
pro_export_path = "Product/Lua/gen"

shutil.rmtress(loc_branch_exc_path,ignore_errors=True)
shutil.rmtress(pro_export_path,ignore_errors=True)

# 解析配置表
cmd = "python ./proton.py -p ./Generator/config/{branch}/excels -f ./Generator/config/{branch}/gen/excels -e lua -s client".format(branch = branch)
os.system(cmd)

# 拷贝配置
shutil.copytree("Generator/config/{branch}/gen".format(branch = branch), pro_export_path)
