using System.Text.RegularExpressions;
        /// Diff part of patch is printed verbatim, everything else (header, warnings, ...) is printed in git encoding (GitModule.SystemEncoding) 
        public List<Patch> CreatePatchesFromString(String patchText)
            string[] lines = patchText.Split('\n');
            for(int i = 0; i < lines.Length; i++)
                input = lines[i];
                    input = GitModule.ReEncodeFileNameFromLossless(input);
                        //header lines are encoded in GitModule.SystemEncoding
                        input = GitModule.ReEncodeStringFromLossless(input, GitModule.SystemEncoding);
                    patch.AppendText(input);
                    if (i < lines.Length - 1)
                        patch.AppendText("\n");
                    input = GitModule.UnquoteFileName(input);
                    Match regexMatch = Regex.Match(input, "[-]{3}[ ][\\\"]{0,1}[aiwco12]/(.*)[\\\"]{0,1}");
                    input = GitModule.UnquoteFileName(input);
                    Match regexMatch = Regex.Match(input, "[+]{3}[ ][\\\"]{0,1}[biwco12]/(.*)[\\\"]{0,1}");
                    input = GitModule.ReEncodeStringFromLossless(input, FilesContentEncoding);
                    input = GitModule.ReEncodeStringFromLossless(input, GitModule.SystemEncoding);                    
                                      "[ ][\\\"]{0,1}[aiwco12]/(.*)[\\\"]{0,1}[ ][\\\"]{0,1}[biwco12]/(.*)[\\\"]{0,1}");
            patch.FileNameA = match.Groups[1].Value.Trim();
            patch.FileNameB = match.Groups[2].Value.Trim();