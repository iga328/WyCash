//----------------------------------------------------------
// 定数
//
	// 環境に合わせて記述
	var OPENCOVER_FOLDER = "C:\\Users\\vkki802430\\AppData\\Local\\Apps\\OpenCover"
	var NUNIT_FOLDER     = "C:\\Program Files (x86)\\NUnit 2.7.0\\bin"

	// 以下は固定
	var POPUP_TITLE = "NUnitTest";

	var OPENCOVER_EXE = OPENCOVER_FOLDER + "\\OpenCover.Console.exe"
	var NUNIT_EXE     = NUNIT_FOLDER + "\\nunit-x86.exe"

	var TARGET_FOLDER = "..\\WyCash\\bin"
	var TEST_FILE     = TARGET_FOLDER + "\\" + "WyCashTest.dll"
	var RESULT_FILE   = "TestResult.xml"
	var COVERAGE_FILE = "TestCoverage.xml"

	var FOLDER_TOOLS          = ".\\_Tools"
	var FOLDER_NUNIT          = ".\\NUnit"
	var FOLDER_NUNIT_RESULT   = FOLDER_NUNIT + "\\Result"
	var FOLDER_NUNIT_COVERAGE = FOLDER_NUNIT + "\\Coverage"

	var RESULT_PATH = TARGET_FOLDER + "\\" + RESULT_FILE
	var RESULT_EXE  = FOLDER_TOOLS + "\\Result\\NUnitReport.CUI.exe"

	var COVERAGE_PATH = TARGET_FOLDER + "\\" + COVERAGE_FILE
	var COVERAGE_EXE  = FOLDER_TOOLS + "\\Coverage\\ReportGenerator.exe"


//----------------------------------------------------------
// 定数(ダイアログボックス)
//
	// 引数：ボタンの種類
	var BTN_OK                 = 0;		// [OK]
	var BTN_OK_CANCEL          = 1;		// [OK][キャンセル]
	var BTN_ABORT_RETRY_IGNORE = 2;		// [中止][再試行][無視]
	var BTN_YES_NO_CANCEL      = 3;		// [はい][いいえ][キャンセル]
	var BTN_YES_NO             = 4;		// [はい][いいえ]
	var BTN_RETRY_CANCEL       = 5;		// [再試行][キャンセル]

	// 引数：アイコンの種類
	var ICON_ERROR             = 16;	// 警告
	var ICON_QUESTION          = 32;	// 問い合わせ
	var ICON_EXCLAMATION       = 48;	// 注意
	var ICON_INFORMATION       = 64;	// 情報

	// 引数：標準のボタン
	var BTN_DEFAULT_1ST        = 0;		// 第1ボタン
	var BTN_DEFAULT_2ND        = 256;	// 第2ボタン
	var BTN_DEFAULT_3RD        = 512;	// 第3ボタン
	var BTN_DEFAULT_4TH        = 768;	// 第4ボタン

	// 返値：押されたボタン
	var BTNR_OK                = 1;		// [OK]
	var BTNR_CANCEL            = 2;		// [キャンセル]
	var BTNR_ABORT             = 3;		// [中止]
	var BTNR_RETRY             = 4;		// [再試行]
	var BTNR_IGNORE            = 5;		// [無視]
	var BTNR_YES               = 6;		// [はい]
	var BTNR_NO                = 7;		// [いいえ]
	var BTNR_NONE              = -1;	// どのボタンも押さなかった


//----------------------------------------------------------
// メイン処理
//
	var fs = WScript.CreateObject( "Scripting.FileSystemObject" );
	var sh = WScript.CreateObject( "WScript.Shell" );

	// 出力フォルダを空にする
	var isExist = fs.FolderExists( FOLDER_NUNIT );
	if( isExist == true )
	{
		fs.DeleteFolder( FOLDER_NUNIT, false );
	}
	fs.CreateFolder( FOLDER_NUNIT );

	// カバレッジを出力するかどうかを確認
	var ret = sh.Popup( "カバレッジを出力しますか？\n" + "   [はい]：出力する\n" + "   [いいえ]：出力しない",
						0, POPUP_TITLE, ( BTN_YES_NO + ICON_QUESTION + BTN_DEFAULT_2ND ) );
	var isCoverage = ( ret == BTNR_YES ) ? true : false;

	if( isCoverage == true )
	{
		// OpenCoverからNUnitを起動
		sh.run( '"' + OPENCOVER_EXE + '"'
			+ " -target:" + '"' + NUNIT_EXE + '"'
			+ " -targetdir:" + '"' + TARGET_FOLDER + '"'
			+ " -targetargs:" + '"' + TEST_FILE + '"'
			+ " -output:" + '"' + COVERAGE_PATH + '"'
			+ " -register:user -mergebyhash -filter:+[RESS-D]RESS_D.*"
			, 1, 1 );
	}
	else
	{
		// 直接NUnitを起動
		sh.run( '"' + NUNIT_EXE + '"'
			+ ' "' + TEST_FILE + '"'
			, 1, 1 );
	}

	// テスト結果出力
	var isExist = fs.FileExists( RESULT_PATH );
	if( isExist == true  )
	{
		sh.run( '"' + RESULT_EXE + '"'
			+ ' "' + RESULT_PATH + '"'
			+ ' "' + FOLDER_NUNIT_RESULT + '"'
			+ "\\TestResult.html"
			, 1, 1 );
	}

	if( isCoverage == true )
	{
		// カバレッジ結果出力
		var isExist = fs.FileExists( COVERAGE_PATH );
		if( isExist == true  )
		{
			sh.run( '"' + COVERAGE_EXE + '"'
				+ ' "' + COVERAGE_PATH + '"'
				+ ' "' + FOLDER_NUNIT_COVERAGE + '"'
				, 1, 1 );
		}
	}

	sh.Popup( "出力完了", 0, POPUP_TITLE, ( BTN_OK + ICON_INFORMATION ) );
	WScript.Quit();
