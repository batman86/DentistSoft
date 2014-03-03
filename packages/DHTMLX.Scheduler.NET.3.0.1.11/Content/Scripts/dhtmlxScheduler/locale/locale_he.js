/*
Copyright Dinamenta, UAB. http://www.dhtmlx.com
To use this component please contact sales@dhtmlx.com to obtain license
*/
Scheduler.plugin(function(a){a.locale={date:{month_full:"\u05d9\u05e0\u05d5\u05d0\u05e8,\u05e4\u05d1\u05e8\u05d5\u05d0\u05e8,\u05de\u05e8\u05e5,\u05d0\u05e4\u05e8\u05d9\u05dc,\u05de\u05d0\u05d9,\u05d9\u05d5\u05e0\u05d9,\u05d9\u05d5\u05dc\u05d9,\u05d0\u05d5\u05d2\u05d5\u05e1\u05d8,\u05e1\u05e4\u05d8\u05de\u05d1\u05e8,\u05d0\u05d5\u05e7\u05d8\u05d5\u05d1\u05e8,\u05e0\u05d5\u05d1\u05de\u05d1\u05e8,\u05d3\u05e6\u05de\u05d1\u05e8".split(","),month_short:"\u05d9\u05e0\u05d5,\u05e4\u05d1\u05e8,\u05de\u05e8\u05e5,\u05d0\u05e4\u05e8,\u05de\u05d0\u05d9,\u05d9\u05d5\u05e0,\u05d9\u05d5\u05dc,\u05d0\u05d5\u05d2,\u05e1\u05e4\u05d8,\u05d0\u05d5\u05e7,\u05e0\u05d5\u05d1,\u05d3\u05e6\u05de".split(","),
day_full:"\u05e8\u05d0\u05e9\u05d5\u05df,\u05e9\u05e0\u05d9,\u05e9\u05dc\u05d9\u05e9\u05d9,\u05e8\u05d1\u05d9\u05e2\u05d9,\u05d7\u05de\u05d9\u05e9\u05d9,\u05e9\u05d9\u05e9\u05d9,\u05e9\u05d1\u05ea".split(","),day_short:"\u05d0,\u05d1,\u05d2,\u05d3,\u05d4,\u05d5,\u05e9".split(",")},labels:{dhx_cal_today_button:"\u05d4\u05d9\u05d5\u05dd",day_tab:"\u05d9\u05d5\u05dd",week_tab:"\u05e9\u05d1\u05d5\u05e2",month_tab:"\u05d7\u05d5\u05d3\u05e9",new_event:"\u05d0\u05e8\u05d5\u05e2 \u05d7\u05d3\u05e9",icon_save:"\u05e9\u05de\u05d5\u05e8",
icon_cancel:"\u05d1\u05d8\u05dc",icon_details:"\u05e4\u05e8\u05d8\u05d9\u05dd",icon_edit:"\u05e2\u05e8\u05d5\u05da",icon_delete:"\u05de\u05d7\u05e7",confirm_closing:"",confirm_deleting:"\u05d0\u05e8\u05d5\u05e2 \u05d9\u05de\u05d7\u05e7 \u05e1\u05d5\u05e4\u05d9\u05ea.\u05dc\u05d4\u05de\u05e9\u05d9\u05da?",section_description:"\u05d4\u05e1\u05d1\u05e8",section_time:"\u05ea\u05e7\u05d5\u05e4\u05d4",confirm_recurring:"\u05d4\u05d0\u05dd \u05d1\u05e8\u05e6\u05d5\u05e0\u05da \u05dc\u05e9\u05e0\u05d5\u05ea \u05db\u05dc \u05e1\u05d3\u05e8\u05ea \u05d0\u05e8\u05d5\u05e2\u05d9\u05dd \u05de\u05ea\u05de\u05e9\u05db\u05d9\u05dd?",
section_recurring:"\u05dc\u05d4\u05e2\u05ea\u05d9\u05e7 \u05d0\u05e8\u05d5\u05e2",button_recurring:"\u05dc\u05d0 \u05e4\u05e2\u05d9\u05dc",button_recurring_open:"\u05e4\u05e2\u05d9\u05dc",full_day:"\u05d9\u05d5\u05dd \u05e9\u05dc\u05dd",button_edit_series:"\u05e2\u05e8\u05d5\u05da \u05d0\u05ea \u05d4\u05e1\u05d3\u05e8\u05d4",button_edit_occurrence:"\u05e2\u05e8\u05d9\u05db\u05ea \u05e2\u05d5\u05ea\u05e7",agenda_tab:"\u05e1\u05d3\u05e8 \u05d9\u05d5\u05dd",date:"\u05ea\u05d0\u05e8\u05d9\u05da",description:"\u05ea\u05d9\u05d0\u05d5\u05e8",
year_tab:"\u05dc\u05e9\u05e0\u05d4",week_agenda_tab:"\u05e1\u05d3\u05e8 \u05d9\u05d5\u05dd",grid_tab:"\u05e1\u05d5\u05e8\u05d2"}}});