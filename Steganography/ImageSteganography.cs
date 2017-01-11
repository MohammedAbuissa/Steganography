using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steganography
{
    public class ImageSteganography : ISteganography<byte[,], bool[,]>
    {
        public bool[,] Find(byte[,] ModifiedMsg)
        {
            if (ModifiedMsg == null)
                throw new ArgumentNullException($"the value of {nameof(ModifiedMsg)} can't be null");

            bool[,] hiddenContent = new bool[ModifiedMsg.GetLength(0),ModifiedMsg.GetLength(1)];
            for (int i = 0; i < ModifiedMsg.GetLength(0); i++)
            {
                for (int j = 0; j < ModifiedMsg.GetLength(1); j++)
                {
                    //even 
                    hiddenContent[i, j] = ModifiedMsg[i, j] % 2 == 0;
                }
            }
            return hiddenContent;
        }

        public byte[,] Hide(bool[,] Content, byte[,] OriginalMsg)
        {
            if (Content == null)
                throw new ArgumentNullException($"the Argument {nameof(Content)} can't be null");
            else if(OriginalMsg == null)
                throw new ArgumentNullException($"the Argument {nameof(OriginalMsg)} can't be null");
            if (Content.GetLength(0) != OriginalMsg.GetLength(0) && Content.GetLength(1) != OriginalMsg.GetLength(1))
                throw new ArgumentException($"{nameof(Content)} and {nameof(OriginalMsg)} don't have the same length");
            byte[,] modifiedMsg = new byte[OriginalMsg.GetLength(0), OriginalMsg.GetLength(1)];
            for (int i = 0; i < OriginalMsg.GetLength(0); i++)
            {
                for (int j = 0; j < OriginalMsg.GetLength(1); j++)
                {
                    var oldPixel = OriginalMsg[i, j];
                    modifiedMsg[i, j] = Content[i,j] == (oldPixel%2==0) ? oldPixel : changeByte(oldPixel);
                }
            }
            return modifiedMsg;
        }

        const byte HalfByte = byte.MaxValue / 2;
        byte changeByte (byte OriginalByte)
        {
            return (byte)(OriginalByte + Sign( HalfByte - OriginalByte));
        }

        int Sign (int Number)
        {
            return (Number > -1 ? 1 : -1);
        }
    }
}
