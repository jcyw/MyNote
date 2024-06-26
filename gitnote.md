---

远程仓库
	创建ssh key
		cd ~/.ssh
		ssh-keygen -t rsa -C "youremail@example.coom"
	判断是否连通
		ssh -T git@github.com(第一次会有警告)

    添加远程仓库
		github 创建库
		本地修改（eg: echo "内容" >> test.txt)
		本地git库初始化：git init
		添加到暂存区：git add test.txt
		提交：git commit -m"说明"
		关联远程仓库：git remote add origin git@github.com:jcyw/test.git
		修改远程仓库：git remote set url origin git@github.com:jcyw/test.git
		推送：git push -u origin master

    如果后面修改test.txt：
			git add test.txt
			git commit -m"说明"
			git push

修改远程仓库地址：
	直接修改：git remote set-url origin 地址
	先删除再添加：git remote rm origin
				git remote add origin 地址
	直接修改配置文件：cd git_test/.git
					vim config(修改[remote "origin"]下的url即可)
	通过第三方git客服端修改

git add -A :添加所有变化
git add -u :添加被修改（modified）和删除（deleted)文件，不包括新文件（new）
git add . :添加新文件和被修改文件，不包括被删除文件

克隆仓库
	克隆：git clone git@github.com:jcyw/test.git
	查看状态：git status
	进入工程文件：cd test

    modified:echo "clone demo" >> clone.txt

    添加and上传：
		git add clone.txt
		git commit -m "说明"
		git push

2020-7-20

时光穿梭：HEAD指向的版本就是当前版本，版本跳转命令：git reset --hard commit_id
		 git log查看提交历史，以便确定回退版本
		 git reflog 查看命令历史，确定要回到未来哪个版本

工作区和暂存区：
		 工作区（本地）---git add-->stage(暂存区)--git commit-->master（分支）

管理修改：git diff HEAD --文件名(.后缀)查看工作区和版本库里面最新版本的区别
		 每当工作区修改一次就要进行一次git add提交到缓存区 修改完成了再git commit

撤销修改：git checkout --file : 1)修改了但是还没有放进暂存区，撤销修改回到原来版本
2）已经放进暂存区，又作了修改，撤销回到添加暂存区后的版本

当你该乱工作区还添加到暂存区后想要丢弃修改：先git reset HEAD `<file>` 再 git checkout -- file(这条命令只能消除工作区修改)

删除文件：git rm file + git commit
		删错了时 （版本库还有的时候）git checkout --file 用版本库版本代替工作区

添加远程仓库：使用git remote add origin 地址 关联，关联后使用git push -u origin master 第一次推送 后面推送使用git push origin master

从远程克隆：git clone 地址 （ssh协议速度最快）

创建与合并分支：查看分支：git branch
			   创建分支：git branch `<name>`
			   切换分支：git checkout `<name>` / git switch `<name>`
			   创建+切换：git checkout -b `<name>` / git switch -c `<name>`
			   合并分支到当前分支：git merge `<name>`
			   删除分支：git branch -d `<name>`

解决冲突：git无法自动合并分支的时候需要我们手动编辑再提交 用git log --graph命令可以查看分支合并图

分支管理策略：Git在合并分支时，会用 Fast forwart模式，但这种情况下，删除分支后，会丢掉分支信息，如果要禁用次模式，Git会在merge时生成一个新的commit，这样从分支历史上可以看出分支信息。 (git merge --no-ff -m "说明" dev)

Bug分支：修复bug时，我们通过创建新的bug分支进行修复，然后合并，最后删除；
		当手头工作没有完成时，先把工作现场git stash（***这个命令只能冻结当前版本有的改动，新增的不能保存***）一下，然后去修复bug，修复后，再git stash pop(这个pop会释放冻结并删除首节点)，回到工作现场；在master分支上修复bug，想要合并到当前dev分支，可以用git cherry-pick `<commit>`命令，把bug提交的修改“复制”到当前分支，避免重复劳动。

feature分支： 开发一个新的feature，最好新建一个分支；
			 如果要丢弃一个没有合并过的分支，可以通过git branch -D `<name>`强行删除。

多人合作： 查看远程库信息，使用git remote -v；
		 本地新建的分支如果不推送到远程，对其他人就是不可见的；
		 从本地创建和远程分支对应的分支，使用git checkout -b branch-name origin/branch-name,本地和远程分支的名称最好一致；
		 建立本地分支和远程分支的关联，使用git branch --set-upstream branch-name origin/branch-name;
		 从远程抓取分支，使用 git pull,如果有冲突，要先解决冲突。

创建标签：git tag `<tagname>`用于新建一个标签，默认为HEAD，
		 也可以指定一个commit (git taget `<name>` `<commit id>`)

    git tag -a`<tagname>` -m "...." 可以指定标签信息
	git tag 可以查看所有标签（标签不是按时间顺序列出，而是按字母排序的）

操作标签：git push origin `<tagname>` 可以推送一个本地标签
		 git push origin --tags 推送全部未推送的本地标签
		 git tag -d `<tagname>` 删除一个本地标签
		 git push origin :refs/tags/`<tagname>` 删除一个远程标签

Review:
	1):建立远程连接：git remote add origin (+url)
	   修改远程连接：git remote set url origin (+url)
	   第一次提交：git push -u origin master 后面提交：git push

    2):时光穿梭：git status : 查看当前仓库状态

    git diff file : 查看file文件工作区和暂存区的不同
				git diff --cached file : 查看file文件暂存区和仓库的不同
				git diff HEAD file : 查看file文件工作区和仓库的不同（按q退出）

    git checkout --file : 将本地修改清0（撤销工作区修改）
				git reset --hard HEAD : 回退当远程版本/清空暂存区（清空暂存区后还需要 讲本地清0）【把仓库最新版本转移到暂存区】

    git log : 查看远程提交日志 （按q退出）
				git log --pretty=oneline : 每个提交日志显示一行

    git reflog : 查看历史命令

    git reset --hard (HEAD^^^/commitID) ： 回退版本

    git rm file 删除文件
				如果需要提交 ： git commit -m"remove file"

    如果删错了 ： git checkout --file

    3):分支管理：git branch : 查看分支
				git branch`<name>` : 创建分支
				git checkout `<name>`  / git switch `<name>` ： 切换分支
				git checkout -b `<name>`  / git switch -c `<name>` : 创建并转到该分支
				git merge `<name>` : 合并name分支到当前分支
				git branch -d `<name>` ： 删除分支
				git branch -D `<name>` : 强行删除一个没有合并的分支
				git push origin --delete `<name>` : 删除远端分支

---

git branch -vv  : 查看本地分支对应远端分支

git config -list : 查看git的相关设置

git log --author=username : 查看指定用户的commit

查看用户名和邮箱地址：

$ git config user.name

$ git config user.email

修改用户名和邮箱地址

$  git config --global user.name  "xxxx"

$  git config --global user.email  "xxxx"

解决 向github提交代码是老要输入用户名密码

$  git config --global credential.helper store

修改文件 --->.gitconfig文件

git remote -a

git branch -a 查看本地和远端分支

git branch -r 查看远端分支

git remote update origin -p	更新远端分支列表

---

************************************新建分支*******************************************
git checkout -b newbranch
git push origin newbranch:newbranch(前面的是本地分支名，后面的是远程分支名)
git branch --set-upstream-to=origin/newbranch

---

************************************修改分支名字***************************************
---本地
如果不在需要修改的分支
	git branch -m 原分支名字 修改的分支名字
如果不在需要修改的分支
	git branch -m 修改的分支名

--远端
	git push origin :老的分支名	（删除老的分支）
	git push --set-upstream origin 新的分支名 （推新的分支设置管理）

---

github 下拉報錯處理
remote: Total 8838 (delta 129), reused 117 (delta 68), pack-reused 8633

这是因为服务器的SSL证书没有经过第三方机构的签署，所以才报错
解决办法:

git config --global http.sslVerify "false" 然後重新拉一下就好了

---

合并其他分支一条记录到本分支
git cherry-pick 60d948e3d2

-----如果回退操作遇见
Unstaged changes after reset:
M       gitnote.txt

解决办法 : git add .
		  git reset --hard

--git show : 查看提交详情
--git show cimmitId : 查看某条提交纪律详情

1. 忽略本地修改，强制拉取远程到本地
   git fetch --all

git reset --hard origin/dev

git fetch -p 修剪远程分支 （刷新远端分支）

---

git命令出现fatal: Unable to create 'xxx/.git/index:File exists.问题
删除在同级目录下 .git 文件中的 index.lock 文件;
或者直接在命令行输入 rm -f .git/index.lock

---

将远程主机 origin 的 master 分支拉取过来，与本地的 brantest 分支合并。

git pull origin master:brantest
如果远程分支是与当前分支合并，则冒号后面的部分可以省略。

git pull origin master

git push origin --delete temp(远端分支名)  -- 删除远端分支

git 删除commit但未push的记录
输入 git reset --soft HEAD~1

soft 表示只删除commit记录，保留代码

1 表示第几条
-------------------------------------------------------------------------------------------~

git index.lock存在怎么解决
 rm -f .git/index.lock
