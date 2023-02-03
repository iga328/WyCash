//----------------------------------------------------------
// �萔
//
	// ���ɍ��킹�ċL�q
	var OPENCOVER_FOLDER = "C:\\Users\\vkki802430\\AppData\\Local\\Apps\\OpenCover"
	var NUNIT_FOLDER     = "C:\\Program Files (x86)\\NUnit 2.7.0\\bin"

	// �ȉ��͌Œ�
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
// �萔(�_�C�A���O�{�b�N�X)
//
	// �����F�{�^���̎��
	var BTN_OK                 = 0;		// [OK]
	var BTN_OK_CANCEL          = 1;		// [OK][�L�����Z��]
	var BTN_ABORT_RETRY_IGNORE = 2;		// [���~][�Ď��s][����]
	var BTN_YES_NO_CANCEL      = 3;		// [�͂�][������][�L�����Z��]
	var BTN_YES_NO             = 4;		// [�͂�][������]
	var BTN_RETRY_CANCEL       = 5;		// [�Ď��s][�L�����Z��]

	// �����F�A�C�R���̎��
	var ICON_ERROR             = 16;	// �x��
	var ICON_QUESTION          = 32;	// �₢���킹
	var ICON_EXCLAMATION       = 48;	// ����
	var ICON_INFORMATION       = 64;	// ���

	// �����F�W���̃{�^��
	var BTN_DEFAULT_1ST        = 0;		// ��1�{�^��
	var BTN_DEFAULT_2ND        = 256;	// ��2�{�^��
	var BTN_DEFAULT_3RD        = 512;	// ��3�{�^��
	var BTN_DEFAULT_4TH        = 768;	// ��4�{�^��

	// �Ԓl�F�����ꂽ�{�^��
	var BTNR_OK                = 1;		// [OK]
	var BTNR_CANCEL            = 2;		// [�L�����Z��]
	var BTNR_ABORT             = 3;		// [���~]
	var BTNR_RETRY             = 4;		// [�Ď��s]
	var BTNR_IGNORE            = 5;		// [����]
	var BTNR_YES               = 6;		// [�͂�]
	var BTNR_NO                = 7;		// [������]
	var BTNR_NONE              = -1;	// �ǂ̃{�^���������Ȃ�����


//----------------------------------------------------------
// ���C������
//
	var fs = WScript.CreateObject( "Scripting.FileSystemObject" );
	var sh = WScript.CreateObject( "WScript.Shell" );

	// �o�̓t�H���_����ɂ���
	var isExist = fs.FolderExists( FOLDER_NUNIT );
	if( isExist == true )
	{
		fs.DeleteFolder( FOLDER_NUNIT, false );
	}
	fs.CreateFolder( FOLDER_NUNIT );

	// �J�o���b�W���o�͂��邩�ǂ������m�F
	var ret = sh.Popup( "�J�o���b�W���o�͂��܂����H\n" + "   [�͂�]�F�o�͂���\n" + "   [������]�F�o�͂��Ȃ�",
						0, POPUP_TITLE, ( BTN_YES_NO + ICON_QUESTION + BTN_DEFAULT_2ND ) );
	var isCoverage = ( ret == BTNR_YES ) ? true : false;

	if( isCoverage == true )
	{
		// OpenCover����NUnit���N��
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
		// ����NUnit���N��
		sh.run( '"' + NUNIT_EXE + '"'
			+ ' "' + TEST_FILE + '"'
			, 1, 1 );
	}

	// �e�X�g���ʏo��
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
		// �J�o���b�W���ʏo��
		var isExist = fs.FileExists( COVERAGE_PATH );
		if( isExist == true  )
		{
			sh.run( '"' + COVERAGE_EXE + '"'
				+ ' "' + COVERAGE_PATH + '"'
				+ ' "' + FOLDER_NUNIT_COVERAGE + '"'
				, 1, 1 );
		}
	}

	sh.Popup( "�o�͊���", 0, POPUP_TITLE, ( BTN_OK + ICON_INFORMATION ) );
	WScript.Quit();
