--Insert statements PAC tabel
USE [PROMASST_MES_V7.3.0_WithTestData]
--first empty current table
DELETE FROM pac_ParDefsProcCellTypes;

insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DefMatOperId', 'BL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('UseSieve', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('AlwaysGenFinesDest', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoCheckStock', 'BL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('MaxBatchSize', 'BL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('MinBatchSize', 'BL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('InitialHLCheckStateFines', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DestinationFines', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('NonePerc', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DestEditMode', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoCheckContam', 'BL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoCodeCompOnDests', 'BL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ArticleIdFines', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ReqRejectArtId', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ExpectedDust', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('GrindPerc', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SchedulingMethode', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('BinDevideField', 'BL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('CreateUnplannedProdProgLine', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('PcpUpdateDestsOfAllBatches', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DestsSelectModeOnExec', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SchedulingNextProcCellIdSeq', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SchedulingLastProcCellId', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SCLEnableForcedStartOption', 'BL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SchedulingSkipPrevNextPCsOfConfig', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SchedulingStartPrefBefComplCluster', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SchedulingDoCodeCompOnCallLevel', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ProdProgLnDefStartOption', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DefSeqNrForNewProdProgLn', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('IsProdPrepProcCell', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ProdPrepPropLocGroupId', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ProdPrepAvailable', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ProdProgLnJoinId', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ProdProgLnBatchSeqId', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('UsedProdPrepProcCells', 'BL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('MaxProdProgLnSize', 'BL', 'False')
--insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DestEditMode', 'CS', 'False')
--insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoCodeCompOnDests', 'CS', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('UseSieve', 'IL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('AlwaysGenFinesDest', 'IL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DefaultNumberOfSampleLabels', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('MaxBadgeIdRouting', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('BulkTripWeighingEnabled', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoCheckStock', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ShowLotId', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SupplyResultsOrganolepticCheck', 'IL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('StopTranspBatchAttrNm', 'IL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SupTripBadgeSelStates', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SwitchToOptionalTransp', 'IL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SupplyRemark2', 'IL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('LastTripBadgeId', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('StopOnCommandAttrNm', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SupplyHectoliterWeight', 'IL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('InitialHLCheckState', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('InitialHLCheckStateFines', 'IL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SupplyMoistureContent', 'IL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SourceLocId', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DestinationFines', 'IL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('MaxTranspDests', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DestEditMode', 'IL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('BulkIntakeProcCells', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SackIntakeProcCells', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('TolIntakeCarrierNoteAmount', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoCheckContam', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('WeighBridgeEnabled', 'IL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SupplyRequiresChemicalTest', 'IL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('PropLocId', 'IL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('NumberOfSampleLabels', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('CommunSupplyLns', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SackTripWeighingEnabled', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoCodeCompOnDests', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ArticleIdFines', 'IL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('PrintIntakeTripRoutenote', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SupplySeller', 'IL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ExpectedDust', 'IL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SupplyReturnReason', 'IL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('MultipleStartAllowed', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SupplyRequiresMicroBiologicalTest', 'IL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('VisibleButtons', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ShowSourceArtId', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('UseLabelRolForIntakeSampleLabels', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('UseWeighBridgeForAmount', 'IL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ShowAllIntakeProcCellsOnDestSelInit', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoOccupyDestOnActivation', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('TrpRegDefCopyMode', 'IL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DestsSelectModeOnExec', 'IL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('LastDeliveryId', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ExpirationDays', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('UseSieve', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('AlwaysGenFinesDest', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('UsedLoadPoints', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('TripPlanSelectOpts', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('TripCsOccupationStates', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('LPOLastCustOrderID', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoCheckStock', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('MTOLoadIncAmount', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('VehicleId', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('MaxBatchSize', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('MinSumFlowOnInputs', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DefaultTripOps', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('TrucksDisplayObjectNm', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DriverNm', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('MinBatchSize', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DelivTripBadgeSelStates', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DefFocusInTripPlanning', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DefAutoLPOAssignOpts', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('MaxSumFlowOnInputs', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('RouteLockedAttr', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('AutoSetCustOrderReady', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('LoadPointBagsTrip', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('OLBatchSelectMode', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('LoadPointContainer', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DefNrOfDelivLabels', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('OptRcp', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('Compartments', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('TripId', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('InitialHLCheckState', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('InitialHLCheckStateFines', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('AutoAssignLPOsAllowed', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DestinationFines', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('TripPlanningDaysAfter', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('OutPropOnDests', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ProcCellForLPOCorr', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DefaultDelivDate', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DestEditMode', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('OLLPOMergeMode', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoCheckContam', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('LicenseId', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('CompartSortMode', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoCodeCompOnDests', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('TripEditWindowSizes', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ArticleIdFines', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('MinAmForFlowCorr', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('TripPlanningDaysBefore', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('PropLocGroupAddOL', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('RouteIsCertified', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ObjectNmDSMProdCode', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ExpectedDust', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('OLBatchSelectOptions', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('MedArtIdMatch', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DefPropLocGroupIdAdd', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('PLGMainStream', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ConsumeAtEOB', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('OnlyExplicitAddOnOL', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('OnlyWeighAfterBatchEnd', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DefaultTripState', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('BatchHasMed', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('LPOWindowSizes', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('AutoSelectLPOpts', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('OLCompMode', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('OLRouteSelectMode', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('CustNm', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('CompositionMode', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('LpoMergeMode', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('HasBatchAlarms', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('NoSievingOnMedInBatch', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('NoSievingOnMedInSF', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('LPOLastDelivID', 'OL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DestsSelectModeOnExec', 'OL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('UseSieve', 'PL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('AlwaysGenFinesDest', 'PL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoCheckStock', 'PL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('OptRcp', 'PL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ProductShape', 'PL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('InitialHLCheckStateFines', 'PL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DestinationFines', 'PL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DestEditMode', 'PL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('MatIsOptional', 'PL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoCheckContam', 'PL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('MakeToOrderProdOrderId', 'PL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoCodeCompOnDests', 'PL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ArticleIdFines', 'PL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('RollPerc', 'PL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ReqRejectArtId', 'PL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ExpectedDust', 'PL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('PLGMainStream', 'PL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('AutoDeclEmptyMinLocStock', 'PL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('CheckActiveBatchesBeforeDeclEmpty2ndBin', 'PL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('CheckActiveBatchesBeforeDeclEmptyNo2ndBin', 'PL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('CheckPlannedBatchesBeforeDeclEmpty2ndBin', 'PL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('CheckPlannedBatchesBeforeDeclEmptyNo2ndBin', 'PL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DestsSelectModeOnExec', 'PL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SCLEnableForcedStartOption', 'PL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('MaxProdProgLnSize', 'PL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoCheckStock', 'SL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ShowLotId', 'SL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('StopTranspBatchAttrNm', 'SL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('AutoGenBinFillOrderProdOrderId', 'SL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('StopOnCommandAttrNm', 'SL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('InitialHLCheckState', 'SL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SourceLocId', 'SL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('MaxTranspDests', 'SL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DestEditMode', 'SL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoCheckContam', 'SL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('PropLocId', 'SL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoCodeCompOnDests', 'SL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('CloneTrnspOrderBefStart', 'SL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('CloneTrnspOrderMode', 'SL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('MultipleStartAllowed', 'SL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('VisibleButtons', 'SL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ShowSourceArtId', 'SL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoOccupyDestOnActivation', 'SL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('TrpRegDefCopyMode', 'SL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DefaultDestination', 'SL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('UseSieve', 'TL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('AlwaysGenFinesDest', 'TL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoCheckStock', 'TL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ShowLotId', 'TL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('StopTranspBatchAttrNm', 'TL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('AutoGenBinFillOrderProdOrderId', 'TL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('StopOnCommandAttrNm', 'TL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('InitialHLCheckState', 'TL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('InitialHLCheckStateFines', 'TL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('SourceLocId', 'TL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DestinationFines', 'TL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('MaxTranspDests', 'TL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DestEditMode', 'TL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoCheckContam', 'TL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('PropLocId', 'TL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoCodeCompOnDests', 'TL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ArticleIdFines', 'TL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('CloneTrnspOrderBefStart', 'TL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ExpectedDust', 'TL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('CloneTrnspOrderMode', 'TL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('MultipleStartAllowed', 'TL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('VisibleButtons', 'TL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('ShowSourceArtId', 'TL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DoOccupyDestOnActivation', 'TL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('TrpRegDefCopyMode', 'TL', 'True')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DefaultDestination', 'TL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('StopTransportActive', 'TL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('StopTransportUnitNm', 'TL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('StopTransportAttrNm', 'TL', 'False')
insert into pac_ParDefsProcCellTypes(pac_ParNm, pac_ProcCellTypeId, pac_IsRequired)Values ('DestsSelectModeOnExec', 'TL', 'False')



