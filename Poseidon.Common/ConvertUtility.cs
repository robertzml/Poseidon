﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Poseidon.Common
{
    /// <summary>
    /// 转换工具类
    /// </summary>
    public static class ConvertUtility
    {
        #region Method
        /// <summary>
        /// 金额转换成大写
        /// </summary>
        /// <param name="money">输入金额</param>
        /// <returns></returns>
        public static string ChnMoney(string money)
        {
            string s = double.Parse(money).ToString("#L#E#D#C#K#E#D#C#J#E#D#C#I#E#D#C#H#E#D#C#G#E#D#C#F#E#D#C#.0B0A");
            string d = Regex.Replace(s, @"((?<=-|^)[^1-9]*)|((?'z'0)[0A-E]*((?=[1-9])|(?'-z'(?=[F-L.]|$))))|((?'b'[F-L])(?'z'0)[0A-L]*((?=[1-9])|(?'-z'(?=[.]|$))))", "${b}${z}");
            return Regex.Replace(d, ".", delegate (Match m) { return "负圆空零壹贰叁肆伍陆柒捌玖空空空空空空空分角拾佰仟万億兆京垓秭穰"[m.Value[0] - '-'].ToString(); });
        }
        #endregion //Method
    }
}
