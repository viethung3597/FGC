create view vPurchaseOrder
as
    select rtrim(a.stt_rec)+'_'+ltrim(a.so_ct)+b.stt_rec0  as Id,
        a.ngay_ct as [Date],
        rtrim(c.stt_rec)+'_'+ltrim(c.so_ct)+'_'+d.stt_rec0 as PurchaseRequestId,
        a.user_id0 as EmployeeId,
        rtrim(e.name) as EmployeeUserName,
        rtrim(e.comment) as EmployeeName,
        rtrim(b.ma_vt) as ItemId,
        rtrim(f.ten_vt) as ItemName,
        f.dvt as UnitId,
        g.ten_dvt as UnitName,
        b.so_luong as Quantity,
        b.ngay_giao as ShipDate
    from (select *
        from ph94
        where ma_ct = 'PO1' or ma_ct = 'PO2') as a
        left join ct94 as b on a.stt_rec = b.stt_rec
        left join (select *
        from ph91
        where ma_ct = 'PR1') as c on left(ltrim(a.so_ct), 6) = left(ltrim(c.so_ct), 6)
        left join ct91 as d on c.stt_rec = d.stt_rec
        left join userinfo as e on a.user_id0 = e.id
        left join dmvt f on b.ma_vt = f.ma_vt
        left join dmdvt g on f.dvt = g.dvt
        
