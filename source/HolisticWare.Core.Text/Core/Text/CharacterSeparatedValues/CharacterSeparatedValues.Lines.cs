﻿// /*
//    Copyright (c) 2018-4
//
//    moljac
//    CharacterSeparatedValues.cs
//
//    Permission is hereby granted, free of charge, to any person
//    obtaining a copy of this software and associated documentation
//    files (the "Software"), to deal in the Software without
//    restriction, including without limitation the rights to use,
//    copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to permit persons to whom the
//    Software is furnished to do so, subject to the following
//    conditions:
//
//    The above copyright notice and this permission notice shall be
//    included in all copies or substantial portions of the Software.
//
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
//    OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
//    NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
//    HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
//    WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
//    FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// */
using System;
using System.Collections.Generic;

namespace Core.Text
{
    public partial class CharacterSeparatedValues
    {
        public IEnumerable<KeyValuePair<string, string[]>> Parse
                                                            (
                                                                string[] lines
                                                            )
        {
            if (null == lines || lines.Length == 0)
            {
                throw new ArgumentException($"Empty or null string[] (input): {nameof(lines)}");
            }

            return this.Parse(lines, this.Separators);
        }

        public IEnumerable<KeyValuePair<string, string[]>> Parse
                                                            (
                                                                string[] lines,
                                                                string[] separators
                                                            )
        {
            if (null == lines || lines.Length == 0)
            {
                throw new ArgumentException($"Empty or null string[] (input): {nameof(lines)}");
            }

            return this.Parse(lines, separators, this.CommentStrings, this.HasHeader);
        }

        public IEnumerable<KeyValuePair<string, string[]>> Parse
                                                            (
                                                                string[] lines,
                                                                string[] separators,
                                                                string[] comment_strings,
                                                                bool is_commented
                                                            )
        {
            string[] keys = null;
            int i = 0;

            if (this.IsHeader(lines[0]))
            {
                keys = this.ParseCommentLine(lines[0]);
                i = 1;
            }

            while (i < lines.Length)
            {
                KeyValuePair<string, string[]> kvp;

                i++;

                yield return kvp;
            }
        }

        public bool IsHeader(string line)
        {
            bool is_commented = false;
            string l = line.TrimStart();
            foreach (string cs in this.CommentStrings)
            {
                if (l.StartsWith(cs, StringComparison.CurrentCulture))
                {
                    is_commented = true;
                    break;
                }

            }

            return is_commented;
        }

        private string[] ParseCommentLine
                                        (
                                            string line
                                        )
        {
            string[] items = line.Split(this.Separators, StringSplitOptions.None);

            return items;
        }

    }
}
