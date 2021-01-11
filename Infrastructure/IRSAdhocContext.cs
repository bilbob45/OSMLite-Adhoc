namespace Infrastructure
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IRSAdhocContext : DbContext
    {
        public IRSAdhocContext(): base("name=IRSAdhocContext")
        {
        }

        public virtual DbSet<C__EFMigrationsHistory> C__EFMigrationsHistory { get; set; }
        public virtual DbSet<t_account_category> t_account_category { get; set; }
        public virtual DbSet<t_app_role_claim> t_app_role_claim { get; set; }
        public virtual DbSet<t_app_user_claim> t_app_user_claim { get; set; }
        public virtual DbSet<t_app_user_login> t_app_user_login { get; set; }
        public virtual DbSet<t_app_user_role> t_app_user_role { get; set; }
        public virtual DbSet<t_app_user_token> t_app_user_token { get; set; }
        public virtual DbSet<t_application_permissions> t_application_permissions { get; set; }
        public virtual DbSet<t_application_roles> t_application_roles { get; set; }
        public virtual DbSet<t_application_users> t_application_users { get; set; }
        public virtual DbSet<t_calendar> t_calendar { get; set; }
        public virtual DbSet<t_calendar_date> t_calendar_date { get; set; }
        public virtual DbSet<t_calendar_detail> t_calendar_detail { get; set; }
        public virtual DbSet<t_calendar_period> t_calendar_period { get; set; }
        public virtual DbSet<t_city> t_city { get; set; }
        public virtual DbSet<t_core_comments_log> t_core_comments_log { get; set; }
        public virtual DbSet<t_core_consumer_complaints_ref_upload> t_core_consumer_complaints_ref_upload { get; set; }
        public virtual DbSet<t_core_dept_members> t_core_dept_members { get; set; }
        public virtual DbSet<t_core_dept_unit> t_core_dept_unit { get; set; }
        public virtual DbSet<t_core_regulating_institution> t_core_regulating_institution { get; set; }
        public virtual DbSet<t_core_reporting_institution> t_core_reporting_institution { get; set; }
        public virtual DbSet<t_core_ri_authorization_level> t_core_ri_authorization_level { get; set; }
        public virtual DbSet<t_core_ri_mapping> t_core_ri_mapping { get; set; }
        public virtual DbSet<t_core_ri_subtype> t_core_ri_subtype { get; set; }
        public virtual DbSet<t_core_ri_type> t_core_ri_type { get; set; }
        public virtual DbSet<t_core_ri_type_auth_level> t_core_ri_type_auth_level { get; set; }
        public virtual DbSet<t_core_user_designation> t_core_user_designation { get; set; }
        public virtual DbSet<t_core_user_grade> t_core_user_grade { get; set; }
        public virtual DbSet<t_core_user_location> t_core_user_location { get; set; }
        public virtual DbSet<t_core_users> t_core_users { get; set; }
        public virtual DbSet<t_core_users_ext> t_core_users_ext { get; set; }
        public virtual DbSet<t_core_users_notification_preference> t_core_users_notification_preference { get; set; }
        public virtual DbSet<t_core_users_password> t_core_users_password { get; set; }
        public virtual DbSet<t_core_users_password_hist> t_core_users_password_hist { get; set; }
        public virtual DbSet<t_core_users_reactivation> t_core_users_reactivation { get; set; }
        public virtual DbSet<t_country> t_country { get; set; }
        public virtual DbSet<t_country_zone> t_country_zone { get; set; }
        public virtual DbSet<t_crsb_bic_codes> t_crsb_bic_codes { get; set; }
        public virtual DbSet<t_crsb_msg_incoming> t_crsb_msg_incoming { get; set; }
        public virtual DbSet<t_crsb_msg_outgoing> t_crsb_msg_outgoing { get; set; }
        public virtual DbSet<t_crsb_msg_source> t_crsb_msg_source { get; set; }
        public virtual DbSet<t_crsb_msg_type> t_crsb_msg_type { get; set; }
        public virtual DbSet<t_currency_code> t_currency_code { get; set; }
        public virtual DbSet<t_currency_group_definition> t_currency_group_definition { get; set; }
        public virtual DbSet<t_currency_grouping> t_currency_grouping { get; set; }
        public virtual DbSet<t_currency_rate> t_currency_rate { get; set; }
        public virtual DbSet<t_currency_rate_type> t_currency_rate_type { get; set; }
        public virtual DbSet<t_currency_type> t_currency_type { get; set; }
        public virtual DbSet<t_datetime_format> t_datetime_format { get; set; }
        public virtual DbSet<t_db_name_defn> t_db_name_defn { get; set; }
        public virtual DbSet<t_db_query_group> t_db_query_group { get; set; }
        public virtual DbSet<t_db_query_group_member> t_db_query_group_member { get; set; }
        public virtual DbSet<t_db_query_group_schema_mapping> t_db_query_group_schema_mapping { get; set; }
        public virtual DbSet<t_db_query_script> t_db_query_script { get; set; }
        public virtual DbSet<t_db_query_user_table_column> t_db_query_user_table_column { get; set; }
        public virtual DbSet<t_db_schema_defn> t_db_schema_defn { get; set; }
        public virtual DbSet<t_db_schema_defn_mig> t_db_schema_defn_mig { get; set; }
        public virtual DbSet<t_db_schema_mapping> t_db_schema_mapping { get; set; }
        public virtual DbSet<t_db_schema_mapping_mig> t_db_schema_mapping_mig { get; set; }
        public virtual DbSet<t_dis_eod_process_dates> t_dis_eod_process_dates { get; set; }
        public virtual DbSet<t_dis_gl_type> t_dis_gl_type { get; set; }
        public virtual DbSet<t_dis_returns> t_dis_returns { get; set; }
        public virtual DbSet<t_dis_returns_details> t_dis_returns_details { get; set; }
        public virtual DbSet<t_dis_ri_conn_param> t_dis_ri_conn_param { get; set; }
        public virtual DbSet<t_dis_ri_eod_date> t_dis_ri_eod_date { get; set; }
        public virtual DbSet<t_dis_ri_gl_code_mapping> t_dis_ri_gl_code_mapping { get; set; }
        public virtual DbSet<t_dis_ri_gl_code_mapping_upload> t_dis_ri_gl_code_mapping_upload { get; set; }
        public virtual DbSet<t_dis_ri_gl_code_mapping_upload_instance> t_dis_ri_gl_code_mapping_upload_instance { get; set; }
        public virtual DbSet<t_dis_ri_gl_code_mapping_upload_validation> t_dis_ri_gl_code_mapping_upload_validation { get; set; }
        public virtual DbSet<t_dis_source_system> t_dis_source_system { get; set; }
        public virtual DbSet<t_dis_source_system_balance> t_dis_source_system_balance { get; set; }
        public virtual DbSet<t_dis_source_system_balance_history> t_dis_source_system_balance_history { get; set; }
        public virtual DbSet<t_dis_source_system_gl_type_mapping> t_dis_source_system_gl_type_mapping { get; set; }
        public virtual DbSet<t_dis_source_system_query> t_dis_source_system_query { get; set; }
        public virtual DbSet<t_dis_submission_item_code_mapping> t_dis_submission_item_code_mapping { get; set; }
        public virtual DbSet<t_dis_submission_reference_calc> t_dis_submission_reference_calc { get; set; }
        public virtual DbSet<t_entity> t_entity { get; set; }
        public virtual DbSet<t_lga_code> t_lga_code { get; set; }
        public virtual DbSet<t_lkup_business_month_convention> t_lkup_business_month_convention { get; set; }
        public virtual DbSet<t_lkup_comments_type> t_lkup_comments_type { get; set; }
        public virtual DbSet<t_lkup_computation_rule_exec_status> t_lkup_computation_rule_exec_status { get; set; }
        public virtual DbSet<t_lkup_consumer_complaints_categories> t_lkup_consumer_complaints_categories { get; set; }
        public virtual DbSet<t_lkup_consumer_complaints_subcategories> t_lkup_consumer_complaints_subcategories { get; set; }
        public virtual DbSet<t_lkup_contravention_type> t_lkup_contravention_type { get; set; }
        public virtual DbSet<t_lkup_fems_book_code_type> t_lkup_fems_book_code_type { get; set; }
        public virtual DbSet<t_lkup_fems_book_code_type_values> t_lkup_fems_book_code_type_values { get; set; }
        public virtual DbSet<t_lkup_frequency> t_lkup_frequency { get; set; }
        public virtual DbSet<t_lkup_penalty_type> t_lkup_penalty_type { get; set; }
        public virtual DbSet<t_lkup_questionnaire_type> t_lkup_questionnaire_type { get; set; }
        public virtual DbSet<t_lkup_wc_schedule_status> t_lkup_wc_schedule_status { get; set; }
        public virtual DbSet<t_lkup_wc_submission_status> t_lkup_wc_submission_status { get; set; }
        public virtual DbSet<t_msg_attachment> t_msg_attachment { get; set; }
        public virtual DbSet<t_msg_delivery_method> t_msg_delivery_method { get; set; }
        public virtual DbSet<t_msg_history> t_msg_history { get; set; }
        public virtual DbSet<t_msg_log> t_msg_log { get; set; }
        public virtual DbSet<t_msg_module> t_msg_module { get; set; }
        public virtual DbSet<t_msg_subtype> t_msg_subtype { get; set; }
        public virtual DbSet<t_msg_template> t_msg_template { get; set; }
        public virtual DbSet<t_msg_type> t_msg_type { get; set; }
        public virtual DbSet<t_ose_exam_document> t_ose_exam_document { get; set; }
        public virtual DbSet<t_ose_exam_returns_mapping> t_ose_exam_returns_mapping { get; set; }
        public virtual DbSet<t_ose_exam_type> t_ose_exam_type { get; set; }
        public virtual DbSet<t_ose_exam_type_document_mapping> t_ose_exam_type_document_mapping { get; set; }
        public virtual DbSet<t_ose_questn> t_ose_questn { get; set; }
        public virtual DbSet<t_pnt_penalty_definition> t_pnt_penalty_definition { get; set; }
        public virtual DbSet<t_pnt_penalty_formula> t_pnt_penalty_formula { get; set; }
        public virtual DbSet<t_pnt_penalty_work_collection_mapping> t_pnt_penalty_work_collection_mapping { get; set; }
        public virtual DbSet<t_rb_artifact> t_rb_artifact { get; set; }
        public virtual DbSet<t_rb_artifact_mig> t_rb_artifact_mig { get; set; }
        public virtual DbSet<t_rb_assertion_complex_operand> t_rb_assertion_complex_operand { get; set; }
        public virtual DbSet<t_rb_assertion_operand> t_rb_assertion_operand { get; set; }
        public virtual DbSet<t_rb_assertion_rule> t_rb_assertion_rule { get; set; }
        public virtual DbSet<t_rb_assertion_rule_dependency_for_intra> t_rb_assertion_rule_dependency_for_intra { get; set; }
        public virtual DbSet<t_rb_assertion_rule_set> t_rb_assertion_rule_set { get; set; }
        public virtual DbSet<t_rb_datasize> t_rb_datasize { get; set; }
        public virtual DbSet<t_rb_datatype> t_rb_datatype { get; set; }
        public virtual DbSet<t_rb_extraction_info> t_rb_extraction_info { get; set; }
        public virtual DbSet<t_rb_extraction_info_mig> t_rb_extraction_info_mig { get; set; }
        public virtual DbSet<t_rb_metadata> t_rb_metadata { get; set; }
        public virtual DbSet<t_rb_metadata_dup> t_rb_metadata_dup { get; set; }
        public virtual DbSet<t_rb_metadata_mig> t_rb_metadata_mig { get; set; }
        public virtual DbSet<t_rb_modification_type> t_rb_modification_type { get; set; }
        public virtual DbSet<t_rb_reason_deactivation> t_rb_reason_deactivation { get; set; }
        public virtual DbSet<t_rb_rest_bvn_tin_mapping> t_rb_rest_bvn_tin_mapping { get; set; }
        public virtual DbSet<t_rb_restricted_field> t_rb_restricted_field { get; set; }
        public virtual DbSet<t_rb_restriction_codes> t_rb_restriction_codes { get; set; }
        public virtual DbSet<t_rb_restriction_data> t_rb_restriction_data { get; set; }
        public virtual DbSet<t_rb_restriction_type> t_rb_restriction_type { get; set; }
        public virtual DbSet<t_rb_retrun_matrix_status> t_rb_retrun_matrix_status { get; set; }
        public virtual DbSet<t_rb_returns_matrix> t_rb_returns_matrix { get; set; }
        public virtual DbSet<t_rb_template_type> t_rb_template_type { get; set; }
        public virtual DbSet<t_rpt_bank_rating_composite_score> t_rpt_bank_rating_composite_score { get; set; }
        public virtual DbSet<t_rpt_computation_bank_rating_scoring> t_rpt_computation_bank_rating_scoring { get; set; }
        public virtual DbSet<t_rpt_computation_bank_rating_setup> t_rpt_computation_bank_rating_setup { get; set; }
        public virtual DbSet<t_rpt_computation_rule> t_rpt_computation_rule { get; set; }
        public virtual DbSet<t_rpt_computation_rule_adjustment> t_rpt_computation_rule_adjustment { get; set; }
        public virtual DbSet<t_rpt_computation_rule_adjustment_table> t_rpt_computation_rule_adjustment_table { get; set; }
        public virtual DbSet<t_rpt_computation_rule_dependency> t_rpt_computation_rule_dependency { get; set; }
        public virtual DbSet<t_rpt_computation_rule_frequency> t_rpt_computation_rule_frequency { get; set; }
        public virtual DbSet<t_rpt_computation_rule_level> t_rpt_computation_rule_level { get; set; }
        public virtual DbSet<t_rpt_computation_rule_metadata> t_rpt_computation_rule_metadata { get; set; }
        public virtual DbSet<t_rpt_computation_rule_metadata_rule_mapping> t_rpt_computation_rule_metadata_rule_mapping { get; set; }
        public virtual DbSet<t_rpt_computation_rule_operator> t_rpt_computation_rule_operator { get; set; }
        public virtual DbSet<t_rpt_computation_rule_recalc_trigger> t_rpt_computation_rule_recalc_trigger { get; set; }
        public virtual DbSet<t_rpt_computation_rule_ri_type_mapping> t_rpt_computation_rule_ri_type_mapping { get; set; }
        public virtual DbSet<t_rpt_computation_rule_run_status> t_rpt_computation_rule_run_status { get; set; }
        public virtual DbSet<t_rpt_computation_rule_type> t_rpt_computation_rule_type { get; set; }
        public virtual DbSet<t_rpt_computation_rule_var> t_rpt_computation_rule_var { get; set; }
        public virtual DbSet<t_rpt_computation_rulebase> t_rpt_computation_rulebase { get; set; }
        public virtual DbSet<t_rpt_computation_rulemakeup> t_rpt_computation_rulemakeup { get; set; }
        public virtual DbSet<t_rpt_computation_rulemakeup_formula> t_rpt_computation_rulemakeup_formula { get; set; }
        public virtual DbSet<t_rpt_computation_rulemakeup_formula_dapo> t_rpt_computation_rulemakeup_formula_dapo { get; set; }
        public virtual DbSet<t_rpt_computation_rulemakeup_formula_qadri> t_rpt_computation_rulemakeup_formula_qadri { get; set; }
        public virtual DbSet<t_rpt_computation_user_var> t_rpt_computation_user_var { get; set; }
        public virtual DbSet<t_rpt_computation_value> t_rpt_computation_value { get; set; }
        public virtual DbSet<t_rpt_computation_value_cmb000> t_rpt_computation_value_cmb000 { get; set; }
        public virtual DbSet<t_rpt_computation_value_simple> t_rpt_computation_value_simple { get; set; }
        public virtual DbSet<t_rpt_computation_value_table> t_rpt_computation_value_table { get; set; }
        public virtual DbSet<t_rpt_contravention_valuation> t_rpt_contravention_valuation { get; set; }
        public virtual DbSet<t_rpt_custom_codes> t_rpt_custom_codes { get; set; }
        public virtual DbSet<t_rpt_group> t_rpt_group { get; set; }
        public virtual DbSet<t_rpt_group_members> t_rpt_group_members { get; set; }
        public virtual DbSet<t_rpt_liq_stress_test_data_defn> t_rpt_liq_stress_test_data_defn { get; set; }
        public virtual DbSet<t_rpt_liq_stress_test_data_reference_calc> t_rpt_liq_stress_test_data_reference_calc { get; set; }
        public virtual DbSet<t_rpt_liq_stress_test_scoring> t_rpt_liq_stress_test_scoring { get; set; }
        public virtual DbSet<t_rpt_liquidity_stress_test> t_rpt_liquidity_stress_test { get; set; }
        public virtual DbSet<t_rpt_report> t_rpt_report { get; set; }
        public virtual DbSet<t_rpt_report_config> t_rpt_report_config { get; set; }
        public virtual DbSet<t_rpt_report_group> t_rpt_report_group { get; set; }
        public virtual DbSet<t_rtn_consumer_complaints_defn> t_rtn_consumer_complaints_defn { get; set; }
        public virtual DbSet<t_rtn_consumer_complaints_valuations> t_rtn_consumer_complaints_valuations { get; set; }
        public virtual DbSet<t_rtn_detailed_imf_srf_cmb> t_rtn_detailed_imf_srf_cmb { get; set; }
        public virtual DbSet<t_rtn_detailed_imf_srf_ins> t_rtn_detailed_imf_srf_ins { get; set; }
        public virtual DbSet<t_rtn_detailed_imf_srf_mfb> t_rtn_detailed_imf_srf_mfb { get; set; }
        public virtual DbSet<t_rtn_detailed_imf_srf_nib> t_rtn_detailed_imf_srf_nib { get; set; }
        public virtual DbSet<t_rtn_detailed_imf_srf_pen> t_rtn_detailed_imf_srf_pen { get; set; }
        public virtual DbSet<t_rtn_detailed_imf_srf_pmb> t_rtn_detailed_imf_srf_pmb { get; set; }
        public virtual DbSet<t_rtn_imf_srf_report_code_ri_type_mapping> t_rtn_imf_srf_report_code_ri_type_mapping { get; set; }
        public virtual DbSet<t_rtn_imf_srf_report_item_code_defn> t_rtn_imf_srf_report_item_code_defn { get; set; }
        public virtual DbSet<t_rtn_imf_srf_report_item_code_reference_calc> t_rtn_imf_srf_report_item_code_reference_calc { get; set; }
        public virtual DbSet<t_rtn_processing_exceptions> t_rtn_processing_exceptions { get; set; }
        public virtual DbSet<t_rtn_rb_bvn_tin> t_rtn_rb_bvn_tin { get; set; }
        public virtual DbSet<t_rtn_rb_tin> t_rtn_rb_tin { get; set; }
        public virtual DbSet<t_rtn_reporting_job> t_rtn_reporting_job { get; set; }
        public virtual DbSet<t_rtn_returns> t_rtn_returns { get; set; }
        public virtual DbSet<t_rtn_returns_dept_mapping> t_rtn_returns_dept_mapping { get; set; }
        public virtual DbSet<t_rtn_returns_details> t_rtn_returns_details { get; set; }
        public virtual DbSet<t_rtn_returns_mig> t_rtn_returns_mig { get; set; }
        public virtual DbSet<t_rtn_returns_work_collection_mapping> t_rtn_returns_work_collection_mapping { get; set; }
        public virtual DbSet<t_rtn_returns_work_collection_mapping_mig> t_rtn_returns_work_collection_mapping_mig { get; set; }
        public virtual DbSet<t_rtn_static_returns_content_mapping> t_rtn_static_returns_content_mapping { get; set; }
        public virtual DbSet<t_rtn_work_collection> t_rtn_work_collection { get; set; }
        public virtual DbSet<t_rtn_work_collection_defn> t_rtn_work_collection_defn { get; set; }
        public virtual DbSet<t_rtn_work_collection_defn_mig> t_rtn_work_collection_defn_mig { get; set; }
        public virtual DbSet<t_rtn_work_collection_defn_optn> t_rtn_work_collection_defn_optn { get; set; }
        public virtual DbSet<t_rtn_work_collection_defn_test> t_rtn_work_collection_defn_test { get; set; }
        public virtual DbSet<t_rtn_work_collection_mapping> t_rtn_work_collection_mapping { get; set; }
        public virtual DbSet<t_rtn_work_collection_mapping_mig> t_rtn_work_collection_mapping_mig { get; set; }
        public virtual DbSet<t_rtn_work_collection_partial_acc> t_rtn_work_collection_partial_acc { get; set; }
        public virtual DbSet<t_rtn_work_collection_schedule> t_rtn_work_collection_schedule { get; set; }
        public virtual DbSet<t_rtn_work_collection_submission> t_rtn_work_collection_submission { get; set; }
        public virtual DbSet<t_rtn_work_collection_submission_optn> t_rtn_work_collection_submission_optn { get; set; }
        public virtual DbSet<t_rtn_work_collection_submission_partial_acc> t_rtn_work_collection_submission_partial_acc { get; set; }
        public virtual DbSet<t_rtn_work_collection_submission_validation> t_rtn_work_collection_submission_validation { get; set; }
        public virtual DbSet<t_sct_db_changes> t_sct_db_changes { get; set; }
        public virtual DbSet<t_sct_db_changes_code_type> t_sct_db_changes_code_type { get; set; }
        public virtual DbSet<t_sct_db_changes_status> t_sct_db_changes_status { get; set; }
        public virtual DbSet<t_sct_db_changes_type> t_sct_db_changes_type { get; set; }
        public virtual DbSet<t_sct_file_packager> t_sct_file_packager { get; set; }
        public virtual DbSet<t_sct_info> t_sct_info { get; set; }
        public virtual DbSet<t_sct_ri_info> t_sct_ri_info { get; set; }
        public virtual DbSet<t_sct_type_download> t_sct_type_download { get; set; }
        public virtual DbSet<t_sct_type_download_count> t_sct_type_download_count { get; set; }
        public virtual DbSet<t_sct_webservice_url> t_sct_webservice_url { get; set; }
        public virtual DbSet<t_sec_active_directory_integration> t_sec_active_directory_integration { get; set; }
        public virtual DbSet<t_sec_win_service> t_sec_win_service { get; set; }
        public virtual DbSet<t_state> t_state { get; set; }
        public virtual DbSet<t_sys_configuration_irs> t_sys_configuration_irs { get; set; }
        public virtual DbSet<t_time_unit> t_time_unit { get; set; }
        public virtual DbSet<t_val_severity_level> t_val_severity_level { get; set; }
        public virtual DbSet<t_workflow> t_workflow { get; set; }
        public virtual DbSet<t_workflow_action> t_workflow_action { get; set; }
        public virtual DbSet<t_workflow_action_type> t_workflow_action_type { get; set; }
        public virtual DbSet<t_workflow_group> t_workflow_group { get; set; }
        public virtual DbSet<t_workflow_group_level> t_workflow_group_level { get; set; }
        public virtual DbSet<t_workflow_group_level_transition> t_workflow_group_level_transition { get; set; }
        public virtual DbSet<t_workflow_group_member> t_workflow_group_member { get; set; }
        public virtual DbSet<t_workflow_module> t_workflow_module { get; set; }
        public virtual DbSet<t_workflow_request> t_workflow_request { get; set; }
        public virtual DbSet<t_workflow_request_action> t_workflow_request_action { get; set; }
        public virtual DbSet<t_workflow_request_event_history> t_workflow_request_event_history { get; set; }
        public virtual DbSet<t_workflow_request_file> t_workflow_request_file { get; set; }
        public virtual DbSet<t_workflow_request_ose_ext> t_workflow_request_ose_ext { get; set; }
        public virtual DbSet<t_workflow_state_type> t_workflow_state_type { get; set; }
        public virtual DbSet<bvn> bvns { get; set; }
        public virtual DbSet<bvntinmassg> bvntinmassgs { get; set; }
        public virtual DbSet<Column_Adjustment> Column_Adjustment { get; set; }
        public virtual DbSet<metatada_mig> metatada_mig { get; set; }
        public virtual DbSet<t_core_reporting_institution_history> t_core_reporting_institution_history { get; set; }
        public virtual DbSet<t_core_ri_mapping_history> t_core_ri_mapping_history { get; set; }
        public virtual DbSet<t_core_ri_type_auth_level_history> t_core_ri_type_auth_level_history { get; set; }
        public virtual DbSet<t_core_ri_type_history> t_core_ri_type_history { get; set; }
        public virtual DbSet<t_fsp_rpt_rs_custom_palette_colors> t_fsp_rpt_rs_custom_palette_colors { get; set; }
        public virtual DbSet<t_fsp_rpt_rs_image> t_fsp_rpt_rs_image { get; set; }
        public virtual DbSet<t_fsp_rpt_rs_object_type> t_fsp_rpt_rs_object_type { get; set; }
        public virtual DbSet<t_fsp_rpt_rs_style> t_fsp_rpt_rs_style { get; set; }
        public virtual DbSet<t_fsp_rpt_rs_stylesheet> t_fsp_rpt_rs_stylesheet { get; set; }
        public virtual DbSet<t_rb_assertion_operand_history> t_rb_assertion_operand_history { get; set; }
        public virtual DbSet<t_rb_assertion_rule_bk> t_rb_assertion_rule_bk { get; set; }
        public virtual DbSet<t_rb_assertion_rule_history> t_rb_assertion_rule_history { get; set; }
        public virtual DbSet<t_rb_assertion_rule_set_history> t_rb_assertion_rule_set_history { get; set; }
        public virtual DbSet<t_rb_assertion_rule_try1> t_rb_assertion_rule_try1 { get; set; }
        public virtual DbSet<t_rb_restricted_field_bkup> t_rb_restricted_field_bkup { get; set; }
        public virtual DbSet<t_rb_restricted_field_history> t_rb_restricted_field_history { get; set; }
        public virtual DbSet<t_rpt_computation_value_table_> t_rpt_computation_value_table_ { get; set; }
        public virtual DbSet<t_rpt_computation_value_table_history> t_rpt_computation_value_table_history { get; set; }
        public virtual DbSet<t_rpt_computation_value_table_temp> t_rpt_computation_value_table_temp { get; set; }
        public virtual DbSet<t_rtn_static_returns_content_mapping_20200623> t_rtn_static_returns_content_mapping_20200623 { get; set; }
        public virtual DbSet<t_rtn_static_returns_content_mapping_backup> t_rtn_static_returns_content_mapping_backup { get; set; }
        public virtual DbSet<tin> tins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<t_application_permissions>()
                .HasMany(e => e.t_application_roles)
                .WithMany(e => e.t_application_permissions)
                .Map(m => m.ToTable("t_role_permissions").MapLeftKey("PermissionId").MapRightKey("RoleId"));

            modelBuilder.Entity<t_application_roles>()
                .HasMany(e => e.t_app_role_claim)
                .WithRequired(e => e.t_application_roles)
                .HasForeignKey(e => e.RoleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_application_roles>()
                .HasMany(e => e.t_app_user_role)
                .WithRequired(e => e.t_application_roles)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_application_users>()
                .HasMany(e => e.t_app_user_claim)
                .WithRequired(e => e.t_application_users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_application_users>()
                .HasMany(e => e.t_app_user_login)
                .WithRequired(e => e.t_application_users)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_application_users>()
                .HasMany(e => e.t_app_user_role)
                .WithOptional(e => e.t_application_users)
                .HasForeignKey(e => e.TApplicationUserId);

            modelBuilder.Entity<t_application_users>()
                .HasMany(e => e.t_app_user_role1)
                .WithRequired(e => e.t_application_users1)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_application_users>()
                .HasMany(e => e.t_app_user_token)
                .WithRequired(e => e.t_application_users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_calendar>()
                .HasMany(e => e.t_calendar_date)
                .WithRequired(e => e.t_calendar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_calendar>()
                .HasMany(e => e.t_calendar_detail)
                .WithRequired(e => e.t_calendar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_calendar>()
                .HasMany(e => e.t_calendar_period)
                .WithRequired(e => e.t_calendar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_calendar>()
                .HasMany(e => e.t_entity)
                .WithRequired(e => e.t_calendar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_dept_unit>()
                .Property(e => e.num_cust_element1)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_dept_unit>()
                .Property(e => e.num_cust_element2)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_dept_unit>()
                .Property(e => e.num_cust_element3)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_dept_unit>()
                .Property(e => e.num_cust_element4)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_dept_unit>()
                .Property(e => e.num_cust_element5)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_dept_unit>()
                .HasMany(e => e.t_core_dept_members)
                .WithRequired(e => e.t_core_dept_unit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_dept_unit>()
                .HasMany(e => e.t_rtn_returns_dept_mapping)
                .WithRequired(e => e.t_core_dept_unit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_regulating_institution>()
                .Property(e => e.num_cust_element1)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_regulating_institution>()
                .Property(e => e.num_cust_element2)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_regulating_institution>()
                .Property(e => e.num_cust_element3)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_regulating_institution>()
                .Property(e => e.num_cust_element4)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_regulating_institution>()
                .Property(e => e.num_cust_element5)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_reporting_institution>()
                .Property(e => e.num_cust_element1)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_reporting_institution>()
                .Property(e => e.num_cust_element2)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_reporting_institution>()
                .Property(e => e.num_cust_element3)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_reporting_institution>()
                .Property(e => e.num_cust_element4)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_reporting_institution>()
                .Property(e => e.num_cust_element5)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_reporting_institution>()
                .HasMany(e => e.t_rpt_computation_value)
                .WithRequired(e => e.t_core_reporting_institution)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_reporting_institution>()
                .HasMany(e => e.t_rpt_computation_value_cmb000)
                .WithRequired(e => e.t_core_reporting_institution)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_reporting_institution>()
                .HasMany(e => e.t_rpt_computation_value_simple)
                .WithRequired(e => e.t_core_reporting_institution)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_reporting_institution>()
                .HasMany(e => e.t_rpt_contravention_valuation)
                .WithRequired(e => e.t_core_reporting_institution)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_reporting_institution>()
                .HasMany(e => e.t_rpt_liq_stress_test_scoring)
                .WithRequired(e => e.t_core_reporting_institution)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_reporting_institution>()
                .HasMany(e => e.t_rpt_computation_bank_rating_scoring)
                .WithRequired(e => e.t_core_reporting_institution)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_reporting_institution>()
                .HasMany(e => e.t_rtn_detailed_imf_srf_cmb)
                .WithRequired(e => e.t_core_reporting_institution)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_reporting_institution>()
                .HasMany(e => e.t_rtn_detailed_imf_srf_ins)
                .WithRequired(e => e.t_core_reporting_institution)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_reporting_institution>()
                .HasMany(e => e.t_rtn_detailed_imf_srf_mfb)
                .WithRequired(e => e.t_core_reporting_institution)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_reporting_institution>()
                .HasMany(e => e.t_rtn_detailed_imf_srf_nib)
                .WithRequired(e => e.t_core_reporting_institution)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_reporting_institution>()
                .HasMany(e => e.t_rtn_detailed_imf_srf_pen)
                .WithRequired(e => e.t_core_reporting_institution)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_reporting_institution>()
                .HasMany(e => e.t_rtn_detailed_imf_srf_pmb)
                .WithRequired(e => e.t_core_reporting_institution)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_reporting_institution>()
                .HasMany(e => e.t_core_ri_mapping)
                .WithRequired(e => e.t_core_reporting_institution)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_reporting_institution>()
                .HasMany(e => e.t_rtn_work_collection_schedule)
                .WithRequired(e => e.t_core_reporting_institution)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_ri_authorization_level>()
                .Property(e => e.capitalization)
                .HasPrecision(25, 2);

            modelBuilder.Entity<t_core_ri_authorization_level>()
                .HasMany(e => e.t_core_ri_mapping)
                .WithRequired(e => e.t_core_ri_authorization_level)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_ri_authorization_level>()
                .HasMany(e => e.t_core_ri_type_auth_level)
                .WithRequired(e => e.t_core_ri_authorization_level)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_ri_type>()
                .HasMany(e => e.t_core_ri_mapping)
                .WithRequired(e => e.t_core_ri_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_ri_type>()
                .HasMany(e => e.t_rpt_computation_value_table)
                .WithRequired(e => e.t_core_ri_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_ri_type>()
                .HasMany(e => e.t_rpt_computation_bank_rating_setup)
                .WithRequired(e => e.t_core_ri_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_ri_type>()
                .HasMany(e => e.t_rtn_imf_srf_report_code_ri_type_mapping)
                .WithRequired(e => e.t_core_ri_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_ri_type>()
                .HasMany(e => e.t_rtn_work_collection_mapping)
                .WithRequired(e => e.t_core_ri_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_ri_type>()
                .HasMany(e => e.t_pnt_penalty_definition)
                .WithRequired(e => e.t_core_ri_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_ri_type>()
                .HasMany(e => e.t_core_ri_type_auth_level)
                .WithRequired(e => e.t_core_ri_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_ri_type>()
                .HasMany(e => e.t_rpt_contravention_valuation)
                .WithRequired(e => e.t_core_ri_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_ri_type>()
                .HasMany(e => e.t_rtn_work_collection)
                .WithRequired(e => e.t_core_ri_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_ri_type>()
                .HasMany(e => e.t_rpt_computation_bank_rating_scoring)
                .WithRequired(e => e.t_core_ri_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_ri_type_auth_level>()
                .Property(e => e.capitalization)
                .HasPrecision(25, 5);

            modelBuilder.Entity<t_core_user_designation>()
                .HasMany(e => e.t_core_users_ext)
                .WithRequired(e => e.t_core_user_designation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_user_grade>()
                .HasMany(e => e.t_core_users_ext)
                .WithRequired(e => e.t_core_user_grade)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_users>()
                .Property(e => e.num_cust_element1)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_users>()
                .Property(e => e.num_cust_element2)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_users>()
                .Property(e => e.num_cust_element3)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_users>()
                .Property(e => e.num_cust_element4)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_users>()
                .Property(e => e.num_cust_element5)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_users>()
                .HasMany(e => e.t_core_dept_members)
                .WithRequired(e => e.t_core_users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_users>()
                .HasMany(e => e.t_core_users_ext)
                .WithRequired(e => e.t_core_users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_users>()
                .HasOptional(e => e.t_core_users_notification_preference)
                .WithRequired(e => e.t_core_users);

            modelBuilder.Entity<t_core_users>()
                .HasOptional(e => e.t_core_users_password)
                .WithRequired(e => e.t_core_users);

            modelBuilder.Entity<t_core_users>()
                .HasMany(e => e.t_core_users_password_hist)
                .WithRequired(e => e.t_core_users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_users>()
                .HasMany(e => e.t_core_users_reactivation)
                .WithRequired(e => e.t_core_users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_users>()
                .HasMany(e => e.t_workflow_group_member)
                .WithRequired(e => e.t_core_users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_core_users>()
                .HasMany(e => e.t_workflow_request)
                .WithRequired(e => e.t_core_users)
                .HasForeignKey(e => e.request_maker_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_country>()
                .Property(e => e.num_cust_element1)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_country>()
                .Property(e => e.num_cust_element2)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_country>()
                .Property(e => e.num_cust_element3)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_country>()
                .Property(e => e.num_cust_element4)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_country>()
                .Property(e => e.num_cust_element5)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_crsb_msg_incoming>()
                .Property(e => e.amount)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_crsb_msg_incoming>()
                .Property(e => e.dollar_equiv)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_crsb_msg_incoming>()
                .Property(e => e.sender_charges)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_crsb_msg_incoming>()
                .Property(e => e.beneficiary_charges)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_crsb_msg_outgoing>()
                .Property(e => e.amount)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_crsb_msg_outgoing>()
                .Property(e => e.dollar_equiv)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_crsb_msg_outgoing>()
                .Property(e => e.sender_charges)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_crsb_msg_outgoing>()
                .Property(e => e.beneficiary_charges)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_crsb_msg_source>()
                .HasMany(e => e.t_crsb_msg_incoming)
                .WithRequired(e => e.t_crsb_msg_source)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_crsb_msg_source>()
                .HasMany(e => e.t_crsb_msg_outgoing)
                .WithRequired(e => e.t_crsb_msg_source)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_crsb_msg_type>()
                .HasMany(e => e.t_crsb_msg_incoming)
                .WithRequired(e => e.t_crsb_msg_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_crsb_msg_type>()
                .HasMany(e => e.t_crsb_msg_outgoing)
                .WithRequired(e => e.t_crsb_msg_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_currency_code>()
                .Property(e => e.num_cust_element1)
                .HasPrecision(9, 4);

            modelBuilder.Entity<t_currency_code>()
                .Property(e => e.num_cust_element2)
                .HasPrecision(9, 4);

            modelBuilder.Entity<t_currency_code>()
                .Property(e => e.num_cust_element3)
                .HasPrecision(9, 4);

            modelBuilder.Entity<t_currency_code>()
                .Property(e => e.num_cust_element4)
                .HasPrecision(9, 4);

            modelBuilder.Entity<t_currency_code>()
                .Property(e => e.num_cust_element5)
                .HasPrecision(9, 4);

            modelBuilder.Entity<t_currency_code>()
                .HasMany(e => e.t_crsb_msg_incoming)
                .WithRequired(e => e.t_currency_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_currency_code>()
                .HasMany(e => e.t_crsb_msg_outgoing)
                .WithRequired(e => e.t_currency_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_currency_group_definition>()
                .HasMany(e => e.t_currency_grouping)
                .WithRequired(e => e.t_currency_group_definition)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_currency_rate>()
                .Property(e => e.rate)
                .HasPrecision(15, 8);

            modelBuilder.Entity<t_currency_rate_type>()
                .HasMany(e => e.t_currency_rate)
                .WithRequired(e => e.t_currency_rate_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_db_query_group>()
                .HasMany(e => e.t_db_query_group_member)
                .WithRequired(e => e.t_db_query_group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_db_query_group>()
                .HasMany(e => e.t_db_query_group_schema_mapping)
                .WithRequired(e => e.t_db_query_group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_db_query_group>()
                .HasMany(e => e.t_db_query_user_table_column)
                .WithRequired(e => e.t_db_query_group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_db_schema_defn>()
                .HasMany(e => e.t_db_query_group_schema_mapping)
                .WithRequired(e => e.t_db_schema_defn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_db_schema_defn>()
                .HasMany(e => e.t_db_schema_mapping)
                .WithRequired(e => e.t_db_schema_defn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_dis_gl_type>()
                .HasMany(e => e.t_dis_source_system_gl_type_mapping)
                .WithRequired(e => e.t_dis_gl_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_dis_returns>()
                .Property(e => e.frequency)
                .IsFixedLength();

            modelBuilder.Entity<t_dis_returns>()
                .Property(e => e.num_cust_element1)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_dis_returns>()
                .Property(e => e.num_cust_element2)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_dis_returns>()
                .Property(e => e.num_cust_element3)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_dis_returns>()
                .Property(e => e.num_cust_element4)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_dis_returns>()
                .Property(e => e.num_cust_element5)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_dis_ri_gl_code_mapping_upload_instance>()
                .HasMany(e => e.t_dis_ri_gl_code_mapping_upload)
                .WithRequired(e => e.t_dis_ri_gl_code_mapping_upload_instance)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_dis_source_system>()
                .HasMany(e => e.t_dis_ri_conn_param)
                .WithRequired(e => e.t_dis_source_system)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_dis_source_system>()
                .HasMany(e => e.t_dis_source_system_query)
                .WithRequired(e => e.t_dis_source_system)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_dis_source_system>()
                .HasMany(e => e.t_dis_source_system_gl_type_mapping)
                .WithRequired(e => e.t_dis_source_system)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_dis_source_system_balance>()
                .Property(e => e.dr_mtd_bal)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_dis_source_system_balance>()
                .Property(e => e.cr_mtd_bal)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_dis_source_system_balance>()
                .Property(e => e.dr_ytd_bal)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_dis_source_system_balance>()
                .Property(e => e.cr_ytd_bal)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_dis_source_system_balance>()
                .Property(e => e.dr_bal)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_dis_source_system_balance>()
                .Property(e => e.cr_bal)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_dis_source_system_balance_history>()
                .Property(e => e.dr_mtd_bal)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_dis_source_system_balance_history>()
                .Property(e => e.cr_mtd_bal)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_dis_source_system_balance_history>()
                .Property(e => e.dr_ytd_bal)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_dis_source_system_balance_history>()
                .Property(e => e.cr_ytd_bal)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_dis_source_system_balance_history>()
                .Property(e => e.dr_bal)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_dis_source_system_balance_history>()
                .Property(e => e.cr_bal)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_entity>()
                .Property(e => e.num_cust_element1)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_entity>()
                .Property(e => e.num_cust_element2)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_entity>()
                .Property(e => e.num_cust_element3)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_entity>()
                .Property(e => e.num_cust_element4)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_entity>()
                .Property(e => e.num_cust_element5)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_entity>()
                .HasMany(e => e.t_rtn_work_collection_defn)
                .WithRequired(e => e.t_entity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_entity>()
                .HasMany(e => e.t_rtn_work_collection)
                .WithRequired(e => e.t_entity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_lkup_business_month_convention>()
                .HasMany(e => e.t_dis_ri_eod_date)
                .WithRequired(e => e.t_lkup_business_month_convention)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_lkup_comments_type>()
                .HasMany(e => e.t_core_comments_log)
                .WithRequired(e => e.t_lkup_comments_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_lkup_computation_rule_exec_status>()
                .Property(e => e.exec_status)
                .IsUnicode(false);

            modelBuilder.Entity<t_lkup_computation_rule_exec_status>()
                .HasMany(e => e.t_rpt_computation_rule_run_status)
                .WithRequired(e => e.t_lkup_computation_rule_exec_status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_lkup_consumer_complaints_categories>()
                .HasMany(e => e.t_lkup_consumer_complaints_subcategories)
                .WithRequired(e => e.t_lkup_consumer_complaints_categories)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_lkup_contravention_type>()
                .Property(e => e.penalty_value)
                .IsFixedLength();

            modelBuilder.Entity<t_lkup_contravention_type>()
                .HasMany(e => e.t_pnt_penalty_formula)
                .WithRequired(e => e.t_lkup_contravention_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_lkup_contravention_type>()
                .HasMany(e => e.t_rpt_contravention_valuation)
                .WithRequired(e => e.t_lkup_contravention_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_lkup_frequency>()
                .Property(e => e.freq_unit)
                .IsFixedLength();

            modelBuilder.Entity<t_lkup_frequency>()
                .HasMany(e => e.t_dis_returns)
                .WithRequired(e => e.t_lkup_frequency)
                .HasForeignKey(e => e.frequency)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_lkup_frequency>()
                .HasMany(e => e.t_rpt_computation_rule_frequency)
                .WithRequired(e => e.t_lkup_frequency)
                .HasForeignKey(e => e.frequency)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_lkup_frequency>()
                .HasMany(e => e.t_rtn_returns)
                .WithRequired(e => e.t_lkup_frequency)
                .HasForeignKey(e => e.frequency)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_lkup_frequency>()
                .HasMany(e => e.t_rtn_work_collection)
                .WithRequired(e => e.t_lkup_frequency)
                .HasForeignKey(e => e.frequency)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_lkup_frequency>()
                .HasMany(e => e.t_rtn_work_collection_defn)
                .WithRequired(e => e.t_lkup_frequency)
                .HasForeignKey(e => e.frequency)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_lkup_frequency>()
                .HasMany(e => e.t_rpt_computation_value_table)
                .WithRequired(e => e.t_lkup_frequency)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_lkup_frequency>()
                .HasMany(e => e.t_pnt_penalty_definition)
                .WithRequired(e => e.t_lkup_frequency)
                .HasForeignKey(e => e.penalty_freq)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_lkup_frequency>()
                .HasMany(e => e.t_pnt_penalty_definition1)
                .WithRequired(e => e.t_lkup_frequency1)
                .HasForeignKey(e => e.frequency)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_lkup_penalty_type>()
                .Property(e => e.penalty_type)
                .IsFixedLength();

            modelBuilder.Entity<t_lkup_penalty_type>()
                .HasMany(e => e.t_pnt_penalty_definition)
                .WithRequired(e => e.t_lkup_penalty_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_lkup_wc_schedule_status>()
                .HasMany(e => e.t_rtn_work_collection_schedule)
                .WithRequired(e => e.t_lkup_wc_schedule_status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_lkup_wc_submission_status>()
                .HasMany(e => e.t_rtn_work_collection_submission)
                .WithRequired(e => e.t_lkup_wc_submission_status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_msg_delivery_method>()
                .HasMany(e => e.t_msg_template)
                .WithRequired(e => e.t_msg_delivery_method)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_msg_history>()
                .Property(e => e.success_flag)
                .IsFixedLength();

            modelBuilder.Entity<t_msg_history>()
                .Property(e => e.msg_status)
                .IsFixedLength();

            modelBuilder.Entity<t_msg_history>()
                .HasMany(e => e.t_msg_attachment)
                .WithRequired(e => e.t_msg_history)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_msg_history>()
                .HasMany(e => e.t_msg_log)
                .WithRequired(e => e.t_msg_history)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_msg_log>()
                .Property(e => e.success_flag)
                .IsFixedLength();

            modelBuilder.Entity<t_msg_module>()
                .HasMany(e => e.t_msg_template)
                .WithRequired(e => e.t_msg_module)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_msg_subtype>()
                .HasMany(e => e.t_msg_template)
                .WithRequired(e => e.t_msg_subtype)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_msg_template>()
                .Property(e => e.num_cust_element1)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_msg_template>()
                .Property(e => e.num_cust_element2)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_msg_template>()
                .Property(e => e.num_cust_element3)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_msg_template>()
                .Property(e => e.num_cust_element4)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_msg_template>()
                .Property(e => e.num_cust_element5)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_msg_template>()
                .HasMany(e => e.t_msg_history)
                .WithRequired(e => e.t_msg_template)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_msg_type>()
                .HasMany(e => e.t_msg_template)
                .WithRequired(e => e.t_msg_type)
                .HasForeignKey(e => e.msg_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_ose_exam_document>()
                .HasMany(e => e.t_ose_exam_type_document_mapping)
                .WithRequired(e => e.t_ose_exam_document)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_ose_exam_type>()
                .HasMany(e => e.t_ose_exam_returns_mapping)
                .WithRequired(e => e.t_ose_exam_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_ose_exam_type>()
                .HasMany(e => e.t_ose_exam_type_document_mapping)
                .WithRequired(e => e.t_ose_exam_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_pnt_penalty_definition>()
                .Property(e => e.frequency)
                .IsFixedLength();

            modelBuilder.Entity<t_pnt_penalty_definition>()
                .Property(e => e.penalty_type)
                .IsFixedLength();

            modelBuilder.Entity<t_pnt_penalty_definition>()
                .Property(e => e.penalty_freq)
                .IsFixedLength();

            modelBuilder.Entity<t_pnt_penalty_definition>()
                .Property(e => e.min_limit_accepted)
                .HasPrecision(20, 4);

            modelBuilder.Entity<t_pnt_penalty_definition>()
                .Property(e => e.max_limit_accepted)
                .HasPrecision(20, 4);

            modelBuilder.Entity<t_pnt_penalty_definition>()
                .Property(e => e.penalty_value)
                .HasPrecision(20, 4);

            modelBuilder.Entity<t_pnt_penalty_definition>()
                .Property(e => e.failed_penalty_value)
                .HasPrecision(20, 4);

            modelBuilder.Entity<t_pnt_penalty_formula>()
                .Property(e => e.object_type)
                .IsFixedLength();

            modelBuilder.Entity<t_rb_artifact>()
                .Property(e => e.return_code)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_artifact>()
                .Property(e => e.xls_path)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_artifact_mig>()
                .Property(e => e.return_code)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_artifact_mig>()
                .Property(e => e.xls_path)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_assertion_operand>()
                .HasMany(e => e.t_rb_assertion_complex_operand)
                .WithRequired(e => e.t_rb_assertion_operand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_assertion_rule>()
                .HasMany(e => e.t_rb_assertion_operand)
                .WithRequired(e => e.t_rb_assertion_rule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_assertion_rule_set>()
                .HasMany(e => e.t_rb_assertion_rule)
                .WithRequired(e => e.t_rb_assertion_rule_set)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_datasize>()
                .Property(e => e.datasize)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_datasize>()
                .Property(e => e.datasize_desc)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_datasize>()
                .HasMany(e => e.t_rb_metadata)
                .WithRequired(e => e.t_rb_datasize)
                .HasForeignKey(e => e.datasize_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_datasize>()
                .HasMany(e => e.t_rb_metadata1)
                .WithRequired(e => e.t_rb_datasize1)
                .HasForeignKey(e => e.datasize_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_datatype>()
                .Property(e => e.datatype_desc)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_datatype>()
                .Property(e => e.datatype)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_datatype>()
                .HasMany(e => e.t_rb_metadata)
                .WithRequired(e => e.t_rb_datatype)
                .HasForeignKey(e => e.datatype_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_datatype>()
                .HasMany(e => e.t_rb_metadata1)
                .WithRequired(e => e.t_rb_datatype1)
                .HasForeignKey(e => e.datatype_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_extraction_info>()
                .Property(e => e.template_code)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_extraction_info>()
                .Property(e => e.template_name)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_extraction_info_mig>()
                .Property(e => e.template_code)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_extraction_info_mig>()
                .Property(e => e.template_name)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata>()
                .Property(e => e.ri_type_code)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata>()
                .Property(e => e.return_code)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata>()
                .Property(e => e.header_desc)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata>()
                .Property(e => e.xml_name)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata>()
                .Property(e => e.header_position)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata>()
                .Property(e => e.table_name)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata>()
                .Property(e => e.actual_label)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata>()
                .Property(e => e.vertical_merged)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata>()
                .Property(e => e.horizontal_merged)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata>()
                .Property(e => e.merged_range)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata>()
                .Property(e => e.iscustom)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata>()
                .Property(e => e.custom_size)
                .HasPrecision(20, 0);

            modelBuilder.Entity<t_rb_metadata>()
                .Property(e => e.precisionz)
                .HasPrecision(2, 0);

            modelBuilder.Entity<t_rb_metadata_dup>()
                .Property(e => e.ri_type_code)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata_dup>()
                .Property(e => e.return_code)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata_dup>()
                .Property(e => e.header_desc)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata_dup>()
                .Property(e => e.xml_name)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata_dup>()
                .Property(e => e.header_position)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata_dup>()
                .Property(e => e.table_name)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata_dup>()
                .Property(e => e.actual_label)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata_dup>()
                .Property(e => e.vertical_merged)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata_dup>()
                .Property(e => e.horizontal_merged)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata_dup>()
                .Property(e => e.merged_range)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata_dup>()
                .Property(e => e.iscustom)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata_dup>()
                .Property(e => e.custom_size)
                .HasPrecision(20, 0);

            modelBuilder.Entity<t_rb_metadata_dup>()
                .Property(e => e.precisionz)
                .HasPrecision(2, 0);

            modelBuilder.Entity<t_rb_metadata_mig>()
                .Property(e => e.ri_type_code)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata_mig>()
                .Property(e => e.return_code)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata_mig>()
                .Property(e => e.header_desc)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata_mig>()
                .Property(e => e.xml_name)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata_mig>()
                .Property(e => e.header_position)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata_mig>()
                .Property(e => e.table_name)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata_mig>()
                .Property(e => e.actual_label)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata_mig>()
                .Property(e => e.vertical_merged)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata_mig>()
                .Property(e => e.horizontal_merged)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_metadata_mig>()
                .Property(e => e.merged_range)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_restriction_codes>()
                .HasMany(e => e.t_rb_restricted_field)
                .WithRequired(e => e.t_rb_restriction_codes)
                .HasForeignKey(e => e.restriction_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_restriction_codes>()
                .HasMany(e => e.t_rb_restricted_field1)
                .WithRequired(e => e.t_rb_restriction_codes1)
                .HasForeignKey(e => e.restriction_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_restriction_codes>()
                .HasMany(e => e.t_rb_restricted_field2)
                .WithRequired(e => e.t_rb_restriction_codes2)
                .HasForeignKey(e => e.restriction_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_restriction_codes>()
                .HasMany(e => e.t_rb_restricted_field3)
                .WithRequired(e => e.t_rb_restriction_codes3)
                .HasForeignKey(e => e.restriction_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_restriction_codes>()
                .HasMany(e => e.t_rb_restricted_field4)
                .WithRequired(e => e.t_rb_restriction_codes4)
                .HasForeignKey(e => e.restriction_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_restriction_codes>()
                .HasMany(e => e.t_rb_restricted_field5)
                .WithRequired(e => e.t_rb_restriction_codes5)
                .HasForeignKey(e => e.restriction_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_restriction_codes>()
                .HasMany(e => e.t_rb_restriction_data)
                .WithRequired(e => e.t_rb_restriction_codes)
                .HasForeignKey(e => e.restriction_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_restriction_codes>()
                .HasMany(e => e.t_rb_restriction_data1)
                .WithRequired(e => e.t_rb_restriction_codes1)
                .HasForeignKey(e => e.restriction_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_restriction_codes>()
                .HasMany(e => e.t_rb_restriction_data2)
                .WithRequired(e => e.t_rb_restriction_codes2)
                .HasForeignKey(e => e.restriction_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_restriction_codes>()
                .HasMany(e => e.t_rb_restriction_data3)
                .WithRequired(e => e.t_rb_restriction_codes3)
                .HasForeignKey(e => e.restriction_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_restriction_codes>()
                .HasMany(e => e.t_rb_restriction_data4)
                .WithRequired(e => e.t_rb_restriction_codes4)
                .HasForeignKey(e => e.restriction_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_restriction_codes>()
                .HasMany(e => e.t_rb_restriction_data5)
                .WithRequired(e => e.t_rb_restriction_codes5)
                .HasForeignKey(e => e.restriction_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_restriction_codes>()
                .HasMany(e => e.t_rb_restriction_data6)
                .WithRequired(e => e.t_rb_restriction_codes6)
                .HasForeignKey(e => e.restriction_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_restriction_codes>()
                .HasMany(e => e.t_rb_restriction_data7)
                .WithRequired(e => e.t_rb_restriction_codes7)
                .HasForeignKey(e => e.restriction_code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_restriction_type>()
                .HasMany(e => e.t_rb_restriction_codes)
                .WithRequired(e => e.t_rb_restriction_type)
                .HasForeignKey(e => e.restriction_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_restriction_type>()
                .HasMany(e => e.t_rb_restriction_codes1)
                .WithRequired(e => e.t_rb_restriction_type1)
                .HasForeignKey(e => e.restriction_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_restriction_type>()
                .HasMany(e => e.t_rb_restriction_codes2)
                .WithRequired(e => e.t_rb_restriction_type2)
                .HasForeignKey(e => e.restriction_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_restriction_type>()
                .HasMany(e => e.t_rb_restriction_codes3)
                .WithRequired(e => e.t_rb_restriction_type3)
                .HasForeignKey(e => e.restriction_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_restriction_type>()
                .HasMany(e => e.t_rb_restriction_codes4)
                .WithRequired(e => e.t_rb_restriction_type4)
                .HasForeignKey(e => e.restriction_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_restriction_type>()
                .HasMany(e => e.t_rb_restriction_codes5)
                .WithRequired(e => e.t_rb_restriction_type5)
                .HasForeignKey(e => e.restriction_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_restriction_type>()
                .HasMany(e => e.t_rb_restriction_codes6)
                .WithRequired(e => e.t_rb_restriction_type6)
                .HasForeignKey(e => e.restriction_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_restriction_type>()
                .HasMany(e => e.t_rb_restriction_codes7)
                .WithRequired(e => e.t_rb_restriction_type7)
                .HasForeignKey(e => e.restriction_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rb_retrun_matrix_status>()
                .HasMany(e => e.t_rb_returns_matrix)
                .WithOptional(e => e.t_rb_retrun_matrix_status)
                .HasForeignKey(e => e.status_code);

            modelBuilder.Entity<t_rb_retrun_matrix_status>()
                .HasMany(e => e.t_rb_returns_matrix1)
                .WithOptional(e => e.t_rb_retrun_matrix_status1)
                .HasForeignKey(e => e.status_code);

            modelBuilder.Entity<t_rb_template_type>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<t_rb_template_type>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<t_rpt_bank_rating_composite_score>()
                .Property(e => e.composite_score_lower_limit)
                .HasPrecision(10, 5);

            modelBuilder.Entity<t_rpt_bank_rating_composite_score>()
                .Property(e => e.composite_score_upper_limit)
                .HasPrecision(10, 5);

            modelBuilder.Entity<t_rpt_bank_rating_composite_score>()
                .Property(e => e.risk_category)
                .IsFixedLength();

            modelBuilder.Entity<t_rpt_computation_bank_rating_scoring>()
                .Property(e => e.rating_score)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rpt_computation_bank_rating_setup>()
                .Property(e => e.component_weight)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rpt_computation_bank_rating_setup>()
                .HasMany(e => e.t_rpt_computation_bank_rating_scoring)
                .WithRequired(e => e.t_rpt_computation_bank_rating_setup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rpt_computation_rule_adjustment>()
                .Property(e => e.analyst_comment)
                .IsUnicode(false);

            modelBuilder.Entity<t_rpt_computation_rule_frequency>()
                .Property(e => e.frequency)
                .IsFixedLength();

            modelBuilder.Entity<t_rpt_computation_rule_run_status>()
                .Property(e => e.execution_comment)
                .IsUnicode(false);

            modelBuilder.Entity<t_rpt_computation_rule_run_status>()
                .Property(e => e.exec_status)
                .IsUnicode(false);

            modelBuilder.Entity<t_rpt_computation_rule_run_status>()
                .Property(e => e.exec_error_msg)
                .IsUnicode(false);

            modelBuilder.Entity<t_rpt_computation_rule_run_status>()
                .Property(e => e.executed_by)
                .IsUnicode(false);

            modelBuilder.Entity<t_rpt_computation_rule_type>()
                .HasMany(e => e.t_rpt_computation_rule_metadata)
                .WithRequired(e => e.t_rpt_computation_rule_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rpt_computation_rule_var>()
                .Property(e => e.divisor)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rpt_computation_rulebase>()
                .HasMany(e => e.t_rpt_computation_rulemakeup)
                .WithRequired(e => e.t_rpt_computation_rulebase)
                .HasForeignKey(e => e.ruleBase_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rpt_computation_rulebase>()
                .HasMany(e => e.t_rpt_computation_rulemakeup_formula)
                .WithRequired(e => e.t_rpt_computation_rulebase)
                .HasForeignKey(e => e.ruleBase_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rpt_computation_rulebase>()
                .HasMany(e => e.t_rpt_computation_rulemakeup1)
                .WithRequired(e => e.t_rpt_computation_rulebase1)
                .HasForeignKey(e => e.ruleBase_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rpt_computation_rulebase>()
                .HasMany(e => e.t_rpt_computation_rulemakeup_formula1)
                .WithRequired(e => e.t_rpt_computation_rulebase1)
                .HasForeignKey(e => e.ruleBase_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rpt_computation_rulemakeup>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<t_rpt_computation_value>()
                .Property(e => e.value)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rpt_computation_value_cmb000>()
                .Property(e => e.value)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rpt_computation_value_simple>()
                .Property(e => e.value)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.freq_unit)
                .IsFixedLength();

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_1)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_2)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_3)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_4)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_5)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_6)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_7)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_8)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_9)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_10)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_11)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_12)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_13)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_14)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_15)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_16)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_17)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_18)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_19)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_20)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_21)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_22)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_23)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_24)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_25)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_26)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_27)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_28)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_29)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_30)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_31)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_32)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_33)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_34)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_35)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_36)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_37)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_38)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_39)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table>()
                .Property(e => e.column_40)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_contravention_valuation>()
                .Property(e => e.amount)
                .HasPrecision(20, 4);

            modelBuilder.Entity<t_rpt_group>()
                .HasMany(e => e.t_rpt_report_group)
                .WithRequired(e => e.t_rpt_group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rpt_group>()
                .HasMany(e => e.t_rpt_group_members)
                .WithRequired(e => e.t_rpt_group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rpt_liq_stress_test_scoring>()
                .Property(e => e.amount)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rpt_liquidity_stress_test>()
                .Property(e => e.lcy_amt)
                .HasPrecision(28, 4);

            modelBuilder.Entity<t_rpt_liquidity_stress_test>()
                .Property(e => e.return_status)
                .IsFixedLength();

            modelBuilder.Entity<t_rpt_report>()
                .HasMany(e => e.t_rpt_report_group)
                .WithRequired(e => e.t_rpt_report)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_consumer_complaints_valuations>()
                .Property(e => e.amount)
                .HasPrecision(23, 12);

            modelBuilder.Entity<t_rtn_detailed_imf_srf_cmb>()
                .Property(e => e.den_lcy_amt)
                .HasPrecision(28, 4);

            modelBuilder.Entity<t_rtn_detailed_imf_srf_cmb>()
                .Property(e => e.den_fcy_amt)
                .HasPrecision(28, 4);

            modelBuilder.Entity<t_rtn_detailed_imf_srf_cmb>()
                .Property(e => e.total)
                .HasPrecision(28, 4);

            modelBuilder.Entity<t_rtn_detailed_imf_srf_cmb>()
                .Property(e => e.return_status)
                .IsFixedLength();

            modelBuilder.Entity<t_rtn_detailed_imf_srf_ins>()
                .Property(e => e.den_lcy_amt)
                .HasPrecision(28, 4);

            modelBuilder.Entity<t_rtn_detailed_imf_srf_ins>()
                .Property(e => e.den_fcy_amt)
                .HasPrecision(28, 4);

            modelBuilder.Entity<t_rtn_detailed_imf_srf_ins>()
                .Property(e => e.total)
                .HasPrecision(28, 4);

            modelBuilder.Entity<t_rtn_detailed_imf_srf_ins>()
                .Property(e => e.return_status)
                .IsFixedLength();

            modelBuilder.Entity<t_rtn_detailed_imf_srf_mfb>()
                .Property(e => e.den_lcy_amt)
                .HasPrecision(28, 4);

            modelBuilder.Entity<t_rtn_detailed_imf_srf_mfb>()
                .Property(e => e.den_fcy_amt)
                .HasPrecision(28, 4);

            modelBuilder.Entity<t_rtn_detailed_imf_srf_mfb>()
                .Property(e => e.total)
                .HasPrecision(28, 4);

            modelBuilder.Entity<t_rtn_detailed_imf_srf_mfb>()
                .Property(e => e.return_status)
                .IsFixedLength();

            modelBuilder.Entity<t_rtn_detailed_imf_srf_nib>()
                .Property(e => e.den_lcy_amt)
                .HasPrecision(28, 4);

            modelBuilder.Entity<t_rtn_detailed_imf_srf_nib>()
                .Property(e => e.den_fcy_amt)
                .HasPrecision(28, 4);

            modelBuilder.Entity<t_rtn_detailed_imf_srf_nib>()
                .Property(e => e.total)
                .HasPrecision(28, 4);

            modelBuilder.Entity<t_rtn_detailed_imf_srf_nib>()
                .Property(e => e.return_status)
                .IsFixedLength();

            modelBuilder.Entity<t_rtn_detailed_imf_srf_pen>()
                .Property(e => e.den_lcy_amt)
                .HasPrecision(28, 4);

            modelBuilder.Entity<t_rtn_detailed_imf_srf_pen>()
                .Property(e => e.den_fcy_amt)
                .HasPrecision(28, 4);

            modelBuilder.Entity<t_rtn_detailed_imf_srf_pen>()
                .Property(e => e.total)
                .HasPrecision(28, 4);

            modelBuilder.Entity<t_rtn_detailed_imf_srf_pen>()
                .Property(e => e.return_status)
                .IsFixedLength();

            modelBuilder.Entity<t_rtn_detailed_imf_srf_pmb>()
                .Property(e => e.den_lcy_amt)
                .HasPrecision(28, 4);

            modelBuilder.Entity<t_rtn_detailed_imf_srf_pmb>()
                .Property(e => e.den_fcy_amt)
                .HasPrecision(28, 4);

            modelBuilder.Entity<t_rtn_detailed_imf_srf_pmb>()
                .Property(e => e.total)
                .HasPrecision(28, 4);

            modelBuilder.Entity<t_rtn_detailed_imf_srf_pmb>()
                .Property(e => e.return_status)
                .IsFixedLength();

            modelBuilder.Entity<t_rtn_rb_bvn_tin>()
                .Property(e => e.bvn)
                .IsUnicode(false);

            modelBuilder.Entity<t_rtn_rb_bvn_tin>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<t_rtn_rb_bvn_tin>()
                .Property(e => e.middlename)
                .IsUnicode(false);

            modelBuilder.Entity<t_rtn_rb_bvn_tin>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<t_rtn_rb_bvn_tin>()
                .Property(e => e.phonenumber1)
                .IsUnicode(false);

            modelBuilder.Entity<t_rtn_rb_bvn_tin>()
                .Property(e => e.phonenumber2)
                .IsUnicode(false);

            modelBuilder.Entity<t_rtn_rb_bvn_tin>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<t_rtn_rb_bvn_tin>()
                .Property(e => e.residentialaddress)
                .IsUnicode(false);

            modelBuilder.Entity<t_rtn_rb_bvn_tin>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<t_rtn_rb_tin>()
                .Property(e => e.tin)
                .IsUnicode(false);

            modelBuilder.Entity<t_rtn_rb_tin>()
                .Property(e => e.tin_tax_payer)
                .IsUnicode(false);

            modelBuilder.Entity<t_rtn_rb_tin>()
                .Property(e => e.contact_number)
                .IsUnicode(false);

            modelBuilder.Entity<t_rtn_rb_tin>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<t_rtn_rb_tin>()
                .Property(e => e.jtb_tin)
                .IsUnicode(false);

            modelBuilder.Entity<t_rtn_rb_tin>()
                .Property(e => e.rc_number)
                .IsUnicode(false);

            modelBuilder.Entity<t_rtn_rb_tin>()
                .Property(e => e.tax_office_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_rtn_rb_tin>()
                .Property(e => e.tax_office_name)
                .IsUnicode(false);

            modelBuilder.Entity<t_rtn_rb_tin>()
                .Property(e => e.tax_payer_address)
                .IsUnicode(false);

            modelBuilder.Entity<t_rtn_rb_tin>()
                .Property(e => e.tax_payer_type)
                .IsUnicode(false);

            modelBuilder.Entity<t_rtn_rb_tin>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<t_rtn_returns>()
                .Property(e => e.frequency)
                .IsFixedLength();

            modelBuilder.Entity<t_rtn_returns>()
                .Property(e => e.num_cust_element1)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_returns>()
                .Property(e => e.num_cust_element2)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_returns>()
                .Property(e => e.num_cust_element3)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_returns>()
                .Property(e => e.num_cust_element4)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_returns>()
                .Property(e => e.num_cust_element5)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_returns>()
                .HasMany(e => e.t_ose_exam_returns_mapping)
                .WithRequired(e => e.t_rtn_returns)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_returns>()
                .HasMany(e => e.t_rtn_returns_dept_mapping)
                .WithRequired(e => e.t_rtn_returns)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_returns>()
                .HasMany(e => e.t_rtn_returns_work_collection_mapping)
                .WithRequired(e => e.t_rtn_returns)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_returns_mig>()
                .Property(e => e.frequency)
                .IsFixedLength();

            modelBuilder.Entity<t_rtn_returns_mig>()
                .Property(e => e.num_cust_element1)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_returns_mig>()
                .Property(e => e.num_cust_element2)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_returns_mig>()
                .Property(e => e.num_cust_element3)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_returns_mig>()
                .Property(e => e.num_cust_element4)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_returns_mig>()
                .Property(e => e.num_cust_element5)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_work_collection>()
                .Property(e => e.frequency)
                .IsFixedLength();

            modelBuilder.Entity<t_rtn_work_collection>()
                .Property(e => e.num_cust_element1)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_work_collection>()
                .Property(e => e.num_cust_element2)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_work_collection>()
                .Property(e => e.num_cust_element3)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_work_collection>()
                .Property(e => e.num_cust_element4)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_work_collection>()
                .Property(e => e.num_cust_element5)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_work_collection_defn>()
                .Property(e => e.frequency)
                .IsFixedLength();

            modelBuilder.Entity<t_rtn_work_collection_defn>()
                .Property(e => e.num_cust_element1)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_work_collection_defn>()
                .Property(e => e.num_cust_element2)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_work_collection_defn>()
                .Property(e => e.num_cust_element3)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_work_collection_defn>()
                .Property(e => e.num_cust_element4)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_work_collection_defn>()
                .Property(e => e.num_cust_element5)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_work_collection_defn>()
                .HasMany(e => e.t_pnt_penalty_work_collection_mapping)
                .WithRequired(e => e.t_rtn_work_collection_defn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_work_collection_defn>()
                .HasMany(e => e.t_rtn_returns_work_collection_mapping)
                .WithRequired(e => e.t_rtn_work_collection_defn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_work_collection_defn>()
                .HasMany(e => e.t_rtn_work_collection_partial_acc)
                .WithRequired(e => e.t_rtn_work_collection_defn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_work_collection_defn>()
                .HasMany(e => e.t_rtn_work_collection_submission_partial_acc)
                .WithRequired(e => e.t_rtn_work_collection_defn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_work_collection_defn>()
                .HasOptional(e => e.t_rtn_work_collection_defn_optn)
                .WithRequired(e => e.t_rtn_work_collection_defn);

            modelBuilder.Entity<t_rtn_work_collection_defn>()
                .HasMany(e => e.t_rtn_work_collection_mapping)
                .WithRequired(e => e.t_rtn_work_collection_defn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_work_collection_defn>()
                .HasMany(e => e.t_rtn_work_collection_schedule)
                .WithRequired(e => e.t_rtn_work_collection_defn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_work_collection_defn_mig>()
                .Property(e => e.frequency)
                .IsFixedLength();

            modelBuilder.Entity<t_rtn_work_collection_defn_mig>()
                .Property(e => e.num_cust_element1)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_work_collection_defn_mig>()
                .Property(e => e.num_cust_element2)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_work_collection_defn_mig>()
                .Property(e => e.num_cust_element3)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_work_collection_defn_mig>()
                .Property(e => e.num_cust_element4)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_work_collection_defn_mig>()
                .Property(e => e.num_cust_element5)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_work_collection_defn_test>()
                .Property(e => e.frequency)
                .IsFixedLength();

            modelBuilder.Entity<t_rtn_work_collection_defn_test>()
                .Property(e => e.num_cust_element1)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_work_collection_defn_test>()
                .Property(e => e.num_cust_element2)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_work_collection_defn_test>()
                .Property(e => e.num_cust_element3)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_work_collection_defn_test>()
                .Property(e => e.num_cust_element4)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_work_collection_defn_test>()
                .Property(e => e.num_cust_element5)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_rtn_work_collection_schedule>()
                .HasMany(e => e.t_rpt_computation_rule_adjustment)
                .WithRequired(e => e.t_rtn_work_collection_schedule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_work_collection_schedule>()
                .HasMany(e => e.t_rpt_computation_rule_run_status)
                .WithRequired(e => e.t_rtn_work_collection_schedule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_work_collection_schedule>()
                .HasMany(e => e.t_rpt_computation_value)
                .WithRequired(e => e.t_rtn_work_collection_schedule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_work_collection_schedule>()
                .HasMany(e => e.t_rpt_computation_value_cmb000)
                .WithRequired(e => e.t_rtn_work_collection_schedule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_work_collection_schedule>()
                .HasMany(e => e.t_rpt_computation_value_simple)
                .WithRequired(e => e.t_rtn_work_collection_schedule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_work_collection_schedule>()
                .HasMany(e => e.t_rtn_detailed_imf_srf_cmb)
                .WithRequired(e => e.t_rtn_work_collection_schedule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_work_collection_schedule>()
                .HasMany(e => e.t_rtn_detailed_imf_srf_ins)
                .WithRequired(e => e.t_rtn_work_collection_schedule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_work_collection_schedule>()
                .HasMany(e => e.t_rtn_detailed_imf_srf_mfb)
                .WithRequired(e => e.t_rtn_work_collection_schedule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_work_collection_schedule>()
                .HasMany(e => e.t_rtn_detailed_imf_srf_nib)
                .WithRequired(e => e.t_rtn_work_collection_schedule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_work_collection_schedule>()
                .HasMany(e => e.t_rtn_detailed_imf_srf_pen)
                .WithRequired(e => e.t_rtn_work_collection_schedule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_work_collection_schedule>()
                .HasMany(e => e.t_rtn_detailed_imf_srf_pmb)
                .WithRequired(e => e.t_rtn_work_collection_schedule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_work_collection_schedule>()
                .HasMany(e => e.t_rtn_work_collection_submission)
                .WithRequired(e => e.t_rtn_work_collection_schedule)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rtn_work_collection_submission>()
                .HasMany(e => e.t_rtn_work_collection_submission_partial_acc)
                .WithRequired(e => e.t_rtn_work_collection_submission)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_sct_db_changes_code_type>()
                .HasMany(e => e.t_sct_db_changes)
                .WithRequired(e => e.t_sct_db_changes_code_type)
                .HasForeignKey(e => e.change_code_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_sct_db_changes_code_type>()
                .HasMany(e => e.t_sct_db_changes1)
                .WithRequired(e => e.t_sct_db_changes_code_type1)
                .HasForeignKey(e => e.change_code_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_sct_db_changes_status>()
                .HasMany(e => e.t_sct_db_changes)
                .WithRequired(e => e.t_sct_db_changes_status)
                .HasForeignKey(e => e.status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_sct_db_changes_status>()
                .HasMany(e => e.t_sct_db_changes1)
                .WithRequired(e => e.t_sct_db_changes_status1)
                .HasForeignKey(e => e.status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_sct_db_changes_type>()
                .HasMany(e => e.t_sct_db_changes)
                .WithRequired(e => e.t_sct_db_changes_type)
                .HasForeignKey(e => e.type_changes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_sct_db_changes_type>()
                .HasMany(e => e.t_sct_db_changes1)
                .WithRequired(e => e.t_sct_db_changes_type1)
                .HasForeignKey(e => e.type_changes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_sct_file_packager>()
                .Property(e => e.extension)
                .IsUnicode(false);

            modelBuilder.Entity<t_sct_info>()
                .Property(e => e.ritype_code)
                .IsUnicode(false);

            modelBuilder.Entity<t_sct_info>()
                .Property(e => e.ritype_desc)
                .IsUnicode(false);

            modelBuilder.Entity<t_sct_info>()
                .Property(e => e.sct_version)
                .IsUnicode(false);

            modelBuilder.Entity<t_sct_ri_info>()
                .Property(e => e.ri_code)
                .IsUnicode(false);

            modelBuilder.Entity<t_sct_ri_info>()
                .Property(e => e.ri_name)
                .IsUnicode(false);

            modelBuilder.Entity<t_sct_ri_info>()
                .Property(e => e.RiTypeId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<t_sct_webservice_url>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<t_sct_webservice_url>()
                .Property(e => e.web_service_url)
                .IsUnicode(false);

            modelBuilder.Entity<t_time_unit>()
                .Property(e => e.time_unit)
                .IsFixedLength();

            modelBuilder.Entity<t_val_severity_level>()
                .Property(e => e.num_cust_element1)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_val_severity_level>()
                .Property(e => e.num_cust_element2)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_val_severity_level>()
                .Property(e => e.num_cust_element3)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_val_severity_level>()
                .Property(e => e.num_cust_element4)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_val_severity_level>()
                .Property(e => e.num_cust_element5)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_val_severity_level>()
                .HasMany(e => e.t_rtn_work_collection_submission_validation)
                .WithRequired(e => e.t_val_severity_level)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow>()
                .HasMany(e => e.t_workflow_group_level)
                .WithRequired(e => e.t_workflow)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow>()
                .HasMany(e => e.t_workflow_request)
                .WithRequired(e => e.t_workflow)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow>()
                .HasMany(e => e.t_workflow_request_event_history)
                .WithRequired(e => e.t_workflow)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow>()
                .HasMany(e => e.t_workflow_action)
                .WithRequired(e => e.t_workflow)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow>()
                .HasMany(e => e.t_workflow_request_action)
                .WithRequired(e => e.t_workflow)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow_action>()
                .HasMany(e => e.t_workflow_group_level_transition)
                .WithRequired(e => e.t_workflow_action)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow_action>()
                .HasMany(e => e.t_workflow_request_action)
                .WithRequired(e => e.t_workflow_action)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow_action>()
                .HasMany(e => e.t_workflow_request_event_history)
                .WithRequired(e => e.t_workflow_action)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow_action_type>()
                .HasMany(e => e.t_workflow_action)
                .WithRequired(e => e.t_workflow_action_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow_group>()
                .HasMany(e => e.t_workflow_group_member)
                .WithRequired(e => e.t_workflow_group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow_group>()
                .HasMany(e => e.t_workflow_group_level)
                .WithRequired(e => e.t_workflow_group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow_group>()
                .HasMany(e => e.t_workflow_request)
                .WithRequired(e => e.t_workflow_group)
                .HasForeignKey(e => e.current_group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow_group>()
                .HasMany(e => e.t_workflow_request_event_history)
                .WithRequired(e => e.t_workflow_group)
                .HasForeignKey(e => e.prev_group_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow_group>()
                .HasMany(e => e.t_workflow_request_action)
                .WithRequired(e => e.t_workflow_group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow_group>()
                .HasMany(e => e.t_workflow_request_event_history1)
                .WithRequired(e => e.t_workflow_group1)
                .HasForeignKey(e => e.current_group_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow_group_level>()
                .HasMany(e => e.t_workflow_group_level_transition)
                .WithRequired(e => e.t_workflow_group_level)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow_group_level_transition>()
                .HasMany(e => e.t_workflow_request_action)
                .WithRequired(e => e.t_workflow_group_level_transition)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow_module>()
                .HasMany(e => e.t_workflow)
                .WithRequired(e => e.t_workflow_module)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow_request>()
                .Property(e => e.num_cust_element1)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_workflow_request>()
                .Property(e => e.num_cust_element2)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_workflow_request>()
                .Property(e => e.num_cust_element3)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_workflow_request>()
                .Property(e => e.num_cust_element4)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_workflow_request>()
                .Property(e => e.num_cust_element5)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_workflow_request>()
                .HasMany(e => e.t_workflow_request_action)
                .WithRequired(e => e.t_workflow_request)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow_request>()
                .HasMany(e => e.t_workflow_request_file)
                .WithRequired(e => e.t_workflow_request)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow_request>()
                .HasOptional(e => e.t_workflow_request_ose_ext)
                .WithRequired(e => e.t_workflow_request);

            modelBuilder.Entity<t_workflow_request>()
                .HasMany(e => e.t_workflow_request_event_history)
                .WithRequired(e => e.t_workflow_request)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow_request_action>()
                .Property(e => e.num_cust_element1)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_workflow_request_action>()
                .Property(e => e.num_cust_element2)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_workflow_request_action>()
                .Property(e => e.num_cust_element3)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_workflow_request_action>()
                .Property(e => e.num_cust_element4)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_workflow_request_action>()
                .Property(e => e.num_cust_element5)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_workflow_request_file>()
                .Property(e => e.num_cust_element1)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_workflow_request_file>()
                .Property(e => e.num_cust_element2)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_workflow_request_file>()
                .Property(e => e.num_cust_element3)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_workflow_request_file>()
                .Property(e => e.num_cust_element4)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_workflow_request_file>()
                .Property(e => e.num_cust_element5)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_workflow_request_ose_ext>()
                .Property(e => e.num_cust_element1)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_workflow_request_ose_ext>()
                .Property(e => e.num_cust_element2)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_workflow_request_ose_ext>()
                .Property(e => e.num_cust_element3)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_workflow_request_ose_ext>()
                .Property(e => e.num_cust_element4)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_workflow_request_ose_ext>()
                .Property(e => e.num_cust_element5)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_workflow_state_type>()
                .HasMany(e => e.t_workflow_request)
                .WithRequired(e => e.t_workflow_state_type)
                .HasForeignKey(e => e.current_state_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow_state_type>()
                .HasMany(e => e.t_workflow_request_action)
                .WithRequired(e => e.t_workflow_state_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow_state_type>()
                .HasMany(e => e.t_workflow_request_event_history)
                .WithRequired(e => e.t_workflow_state_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_workflow_state_type>()
                .HasMany(e => e.t_workflow_request_file)
                .WithRequired(e => e.t_workflow_state_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<metatada_mig>()
                .Property(e => e.return_code)
                .IsUnicode(false);

            modelBuilder.Entity<metatada_mig>()
                .Property(e => e.table_name)
                .IsUnicode(false);

            modelBuilder.Entity<metatada_mig>()
                .Property(e => e.header_desc)
                .IsUnicode(false);

            modelBuilder.Entity<metatada_mig>()
                .Property(e => e.header_position)
                .IsUnicode(false);

            modelBuilder.Entity<metatada_mig>()
                .Property(e => e.new_header)
                .IsUnicode(false);

            modelBuilder.Entity<t_core_reporting_institution_history>()
                .Property(e => e.num_cust_element1)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_reporting_institution_history>()
                .Property(e => e.num_cust_element2)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_reporting_institution_history>()
                .Property(e => e.num_cust_element3)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_reporting_institution_history>()
                .Property(e => e.num_cust_element4)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_reporting_institution_history>()
                .Property(e => e.num_cust_element5)
                .HasPrecision(25, 8);

            modelBuilder.Entity<t_core_ri_type_auth_level_history>()
                .Property(e => e.capitalization)
                .HasPrecision(25, 5);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.freq_unit)
                .IsFixedLength();

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_1)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_2)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_3)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_4)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_5)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_6)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_7)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_8)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_9)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_10)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_11)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_12)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_13)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_14)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_15)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_16)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_17)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_18)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_19)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_20)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_21)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_22)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_23)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_24)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_25)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_26)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_27)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_28)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_29)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_30)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_31)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_32)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_33)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_34)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_35)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_36)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_37)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_38)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_39)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_>()
                .Property(e => e.column_40)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.freq_unit)
                .IsFixedLength();

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_1)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_2)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_3)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_4)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_5)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_6)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_7)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_8)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_9)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_10)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_11)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_12)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_13)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_14)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_15)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_16)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_17)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_18)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_19)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_20)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_21)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_22)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_23)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_24)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_25)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_26)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_27)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_28)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_29)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_30)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_31)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_32)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_33)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_34)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_35)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_36)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_37)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_38)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_39)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_history>()
                .Property(e => e.column_40)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.freq_unit)
                .IsFixedLength();

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_1)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_2)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_3)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_4)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_5)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_6)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_7)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_8)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_9)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_10)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_11)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_12)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_13)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_14)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_15)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_16)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_17)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_18)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_19)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_20)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_21)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_22)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_23)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_24)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_25)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_26)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_27)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_28)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_29)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_30)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_31)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_32)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_33)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_34)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_35)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_36)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_37)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_38)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_39)
                .HasPrecision(38, 8);

            modelBuilder.Entity<t_rpt_computation_value_table_temp>()
                .Property(e => e.column_40)
                .HasPrecision(38, 8);
        }
    }
}
