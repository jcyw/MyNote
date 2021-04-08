##########查找并输出重名文件
import os, re

arrFiles = []
arrPath = []

# 遍历文件夹
def walkFile(file):
    for root, dirs, files in os.walk(file):

        # root 表示当前正在访问的文件夹路径
        # dirs 表示该文件夹下的子目录名list
        # files 表示该文件夹下的文件list

        # 遍历文件 f->文件名
        for f in files:
            # print(os.path.join(root, f))
            # 查找后缀名为.txt的文件
            # if f.endswith('.txt'):
            #     print(f)

            # if re.match(r'^.*?\.(txt)+$',f):
            #     print(f)
            arrFiles.append(f)
            arrPath.append(os.path.join(root, f))

        # 遍历所有的文件夹
        # for d in dirs:
        #     # print(os.path.join(root, d))
        #     arrPath.append(d)

##输出重名文件
def findSameName(fileList):
    tempArr = fileList.copy()
    for k in range(len(tempArr)):
        for k1 in range(len(fileList)):
            if tempArr[k] == fileList[k1] and k < k1:
                print("\n重名文件名============>",tempArr[k])
                printSmaeNamePath(tempArr[k])

##输出重名路径
def printSmaeNamePath(fileName):
    print("<=================重名路径===================>")
    for v in arrPath:
        if fileName in v:
            print(v)


##输出数组
def printArr(arr):
    for v in arr:
        print(v)

def main():
    walkFile("d:/test/")
    #########
    # print(arrFiles)
    # print("----------------------------------")
    findSameName[arrFiles]


if __name__ == '__main__':
    main()