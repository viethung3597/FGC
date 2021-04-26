create view vPurchaseRequest
as
    select rtrim(a.stt_rec)+'_'+ltrim(a.so_ct)+'_'+b.stt_rec0 as Id,
        a.ngay_ct as [Date],
        a.user_id0 as EmployeeId,
        rtrim(f.name) as EmployeeUserName,
        rtrim(f.comment) as EmployeeName,
        a.ma_gd as TypeId,
        c.ten_gd as TypeName,
        a.ma_md as PriorityId,
        d.ten_md as PriorityName,
        a.dept_id as DepartmentId,
        e.ten_bp as DepartmentName,
        cast(iif(a.[status] = '2', 0 , 1) as bit) as IsFinalApproved,
        g.cap_duyet as LastApprovedLevel,
        g.[date] as LastApprovedAt,
        rtrim(b.ma_vt) as ItemId,
        rtrim(h.ten_vt) as ItemName,
        h.dvt as UnitId,
        k.ten_dvt as UnitName,
        b.so_luong as Quantity,
        h.so_ngay_dh as LeadtimeDate
    from (select *
        from ph91
        where ma_ct = 'PR1') as a
        left join ct91 as b on a.stt_rec = b.stt_rec
        left join (select ma_gd, ten_gd
        from dmmagd
        where ma_ct = 'PR1' and loai_ct = '1') as c on a.ma_gd = c.ma_gd
        left join (select ma_md, ten_md
        from dmmd
        where ma_ct = 'PR1' ) as d on a.ma_md = d.ma_md
        left join dmbp as e on a.dept_id = e.ma_bp
        left join userinfo as f on a.user_id0 = f.id
        left join (select stt_rec, max ([date]) as [date], max(line_nbr) as cap_duyet
        from v_approve
        where [status] = 1
        group by stt_rec) g on a.stt_rec = g.stt_rec
        left join dmvt h on b.ma_vt = h.ma_vt
        left join dmdvt k on h.dvt = k.dvt
        
