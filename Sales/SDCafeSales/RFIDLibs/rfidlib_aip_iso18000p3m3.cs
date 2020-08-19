using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace RFIDLIB
{
    class rfidlib_aip_iso18000p3m3
    {
#if UNICODE
         [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
         public static extern UInt32  ISO18000p3m3_GetLibVersion(StringBuilder buf, UInt32 nSize) ;

        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern UIntPtr  ISO18000p3m3_CreateInvenParam(UIntPtr hInvenParamSpecList,
													 Byte AntennaID /* By default set to 0,apply to all antenna */,
													Byte Sel,
												   Byte Session,
													Byte Q 
													 )  ;
        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO18000p3m3_SetInvenSelectParam(UIntPtr hIso18000p3m3InvenParam ,
											        Byte target ,
													 Byte action ,
													  Byte memBank ,
													    UInt32 dwPointer,
                                                        Byte[] maskBits,
														  Byte maskBitLen,
														  Byte truncate) ;
        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO18000p3m3_SetInvenReadParam(UIntPtr hIso18000p3m3InvenParam ,Byte MemBank ,UInt32 WordPtr,Byte WordCount) ;


        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO18000p3m3_ParseTagDataReport(UIntPtr hTagReport,
												  ref UInt32 aip_id,
												   ref UInt32 tag_id,
												   ref UInt32  ant_id,
												  ref UInt32 metaFlags,
												  Byte[] tagdata,
												  ref UInt32 tagDataLen)   ;

        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO18000p3m3_Connect(UIntPtr hr ,
									   UInt32 tagType,//0:reader default setting
									  Byte[] epcBits ,
								   UInt32 epcBitsLen ,
								   Byte setPwd, /* 是否验证access password */
								   UInt32 accessPwd,
									   ref UIntPtr ht
									   )  ;


        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO18000p3m3_Read(UIntPtr hr ,
									UIntPtr ht ,
									Byte memBank,
									UInt32 startWord,
									Byte wordCnt,
									Byte[] wordBuffer,
									ref UInt32 nSize /* In:size of buffer ;Out:bytes written 	*/
								 ) ;
        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int  ISO18000p3m3_Write(UIntPtr hr ,
									 UIntPtr ht ,
									 Byte memBank,
									 UInt32 startWord,
									 Byte wordCnt,
                                     Byte[] wordData,
                                     UInt32 nSize);

        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO18000p3m3_Lock(UIntPtr hr ,
										UIntPtr ht ,
										UInt16 mask ,
										UInt16 action 
										) ;
        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO18000p3m3_Kill(UIntPtr hr,
                                        UIntPtr ht,
										UInt32 password ,
										Byte recommission) ;
        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
         public static extern int  ISO18000p3m3_ReadPC(UIntPtr hr,
								UIntPtr ht,
									ref UInt16 pc);

        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO18000p3m3_WritePC(UIntPtr hr,
                                UIntPtr ht,
                                UInt16 mask,
                                    UInt16 pc);

#else
        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
         public static extern UInt32  ISO18000p3m3_GetLibVersion(StringBuilder buf, UInt32 nSize) ;

        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UIntPtr  ISO18000p3m3_CreateInvenParam(UIntPtr hInvenParamSpecList,
													 Byte AntennaID /* By default set to 0,apply to all antenna */,
													Byte Sel,
												   Byte Session,
													Byte Q 
													 )  ;
        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO18000p3m3_SetInvenSelectParam(UIntPtr hIso18000p3m3InvenParam,
                                                    Byte target,
                                                     Byte action,
                                                      Byte memBank,
                                                        UInt32 dwPointer,
                                                        Byte[] maskBits,
                                                          Byte maskBitLen,
                                                          Byte truncate);
        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO18000p3m3_SetInvenReadParam(UIntPtr hIso18000p3m3InvenParam, Byte MemBank, UInt32 WordPtr, Byte WordCount);


        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO18000p3m3_ParseTagDataReport(UIntPtr hTagReport,
												  ref UInt32 aip_id,
												   ref UInt32 tag_id,
												   ref UInt32  ant_id,
												  ref UInt32 metaFlags,
												  Byte[] tagdata,
												  ref UInt32 tagDataLen)   ;

        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO18000p3m3_Connect(UIntPtr hr ,
									   UInt32 tagType,//0:reader default setting
									  Byte[] epcBits ,
								   UInt32 epcBitsLen ,
								   Byte setPwd, /* 是否验证access password */
								   UInt32 accessPwd,
									   ref UIntPtr ht
									   )  ;


        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO18000p3m3_Read(UIntPtr hr ,
									UIntPtr ht ,
									Byte memBank,
									UInt32 startWord,
									Byte wordCnt,
									Byte[] wordBuffer,
									ref UInt32 nSize /* In:size of buffer ;Out:bytes written 	*/
								 ) ;
        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int  ISO18000p3m3_Write(UIntPtr hr ,
									 UIntPtr ht ,
									 Byte memBank,
									 UInt32 startWord,
									 Byte wordCnt,
									 Byte[] wordData,
                                     UInt32 nSize) ;

        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO18000p3m3_Lock(UIntPtr hr ,
										UIntPtr ht ,
										UInt16 mask ,
										UInt16 action 
										) ;

        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO18000p3m3_Kill(UIntPtr hr,
                                        UIntPtr ht,
										UInt32 password ,
										Byte recommission) ;

        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
         public static extern int  ISO18000p3m3_ReadPC(UIntPtr hr,
								UIntPtr ht,
									ref UInt16 pc);

        [DllImport("rfidlib_aip_iso18000p3m3.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int ISO18000p3m3_WritePC(UIntPtr hr,
                                UIntPtr ht,
                                UInt16 mask,
                                    UInt16 pc);
#endif

    }
}
