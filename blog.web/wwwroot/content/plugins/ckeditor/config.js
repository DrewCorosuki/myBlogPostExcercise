///**
// * @license Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.
// * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
// */

CKEDITOR.editorConfig = function (config) {
	config.skin = 'moono-lisa';
	config.height = 100;
	config.toolbarGroups = [
		//{ name: 'clipboard', groups: ['clipboard', 'undo'] },
		{ name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
		{ name: 'document', groups: ['mode', 'document', 'doctools'] },
		{ name: 'forms', groups: ['forms'] },
		{ name: 'basicstyles', groups: ['basicstyles'] },
		{ name: 'paragraph', groups: ['list'] },
		//{ name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
		/*{ name: 'links', groups: ['links'] },*/
		//{ name: 'insert', groups: ['insert'] },
		//{ name: 'styles', groups: ['styles'] },
		//{ name: 'colors', groups: ['colors'] },
		/*{ name: 'tools', groups: ['tools'] },*/
		//{ name: 'others', groups: ['others'] },
		//{ name: 'about', groups: ['about'] }
	];
	//config.disableNativeSpellChecker = false;
	config.scayt_autoStartup = true;
};