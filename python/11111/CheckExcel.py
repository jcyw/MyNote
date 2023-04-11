#!/usr/bin/python3
# --** coding="UTF-8" **--
# author:zhanzhang

import configparser
import os
import pandas as pd

readRecord = []


# -- 读取配置文件
def readConfig():
    config = configparser.ConfigParser()
    config.read('CheckExcel.ini', encoding='utf-8')
    global TargetPath
    TargetPath = config.get('config', 'TargetPath')
    global FindPath
    FindPath = config.get('config', 'FindPath')
    global ExportPath
    ExportPath = config.get('config', 'ExportPath')
    print("完成读取配置")


def openExcel(excelpath):
    if os.path.exists(excelpath):
        excelbook = pd.read_excel(excelpath)
        return excelbook, True
    else:
        return None, False


def changeNum(num):
    return chr(96 + num)


# 遍历目标文件夹所有Excel文件
def findFile():
    global TargetPath
    global readRecord
    readRecord.append(["目标excel", "目标单元格", "查询ID","点击直接跳转"])
    list, isExist = openExcel(TargetPath)
    if not isExist:
        print("目标Excel路径不存在")
        return
    print("拼命运行ing...")
    list = pd.DataFrame(list)
    try:
        url = '<a href="{}">{}</a>'
        for root, ds, fs in os.walk(FindPath):
            for f in fs:
                if f.endswith('.xlsx') or f.endswith(".xls"):
                    fullname = os.path.join(root, f)
                    sheetList = pd.read_excel(fullname, None)
                    for sheetName in sheetList:
                        if "|" in sheetName:
                            print(sheetName)
                            index = 0
                            excel = pd.DataFrame(sheetList[sheetName])
                            for findKey in list["Id"]:
                                for info in excel.itertuples():
                                    itIndex = -1
                                    for val in info:
                                        itIndex += 1
                                        if (isinstance(val, str)) and str(findKey) in val or (findKey == val):
                                            cellName = changeNum(itIndex) + str(info[0] + 2)
                                            jumpPath = '=HYPERLINK("[{}]\'{}\'!{}","前往")'.format(fullname,
                                                                                                 str(sheetName),
                                                                                                 cellName)
                                            # sheetName,changeNum(itIndex)+str(info[0]+2)
                                            writeName = fullname
                                            print(writeName)
                                            readRecord.append([fullname, cellName, findKey, jumpPath])
                                            # print(str(itIndex) + "列数")
                                            # print(str(info[0]) + "行数")

                                        # elif (findKey == val):
                                        #     writeName = '=HYPERLINK("{}", "{}")'.format(fullname, fullname)
                                        #     readRecord.append([writeName, changeNum(itIndex)+str(info[0]+2), findKey])
                                        #     # print(str(itIndex) + "列数")
                                        #     # print(str(info[0]) + "行数")
                            # for df in sheetList[sheetName].values:
                            #     index += 1
                            #     if index >= 4:
                            #         for findKey in list["Id"]:
                            #             print(str(findKey))
                            #             dfIndex = 0
                            #             for val in df:
                            #                 print(val)
                            #                 if (isinstance(val, str)) and str(findKey) in val:
                            #                     readRecord.append([fullname, df[0], findKey])
                            #
                            #                 elif (findKey == val):
                            #                     readRecord.append([fullname, df[0], findKey])


    except Exception as r:
        print("抛出异常")
        print("%s", r)


def saveRecord():
    global readRecord
    global ExportPath
    neExcel = pd.DataFrame(data=readRecord)
    neExcel.to_excel(ExportPath, "Sheet", index=False, header=True)
    input("完成检测，请于ExprotPath路径查询结果")


if __name__ == "__main__":
    print("开始运行")
    readConfig()
    findFile()
    saveRecord()
