using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CsvDataParsing<T>
    where T : class, ICsvParsable, new()
{
    // csv 파싱 정규식 
    private string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    private string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";

    // 파일 이름 
    private static string directoryName = "CsvConverter";
    private string fileName;

    // 만들어놓은거 담아놓기
    List<T> dataArray;

    public CsvDataParsing(string fName)
    {
        this.fileName = fName;

        Debug.Log(fileName);

        dataArray = new List<T>();

        InitCsv();
    }


    private void InitCsv()
    {
        // Resouce파일에 저장된 텍스트 파일 가져오기 
        TextAsset _textAsset = Resources.Load(directoryName + "/" + fileName) as TextAsset;

        if (_textAsset == null)
        {
            Debug.LogError($"파일을 찾을 수 없습니다: {fileName}");
            return;
        }
        else if (string.IsNullOrWhiteSpace(_textAsset.text))
        {
            Debug.LogError($"CSV 파일이 존재하지 않거나 비어 있습니다: {fileName}");
            return;
        }

        try
        {
            // 행별로 자르기
            string[] lines = Regex.Split(_textAsset.text, LINE_SPLIT_RE);

            // 첫번째 행 자르기 
            string[] header = Regex.Split(lines[0], SPLIT_RE);

            for (int i = 1; i < lines.Length; i++)
            {
                // 단어별로 자르기 
                string[] values = Regex.Split(lines[i], SPLIT_RE);

                ProcessData(values);
            }

        }
        catch (Exception e)
        {
            Debug.LogError($"CSV 파싱 중 오류 발생: {e.Message}");
        }


    }

    private void ProcessData(string[] lines)
    {
        T data = new T();
        data.Parse(lines);

        dataArray.Add(data);
    }

    public List<T> GetDataArray()
    {
        return dataArray;
    }
}
